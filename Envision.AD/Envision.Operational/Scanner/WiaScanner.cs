using System;
using System.Collections.Generic;
using System.IO;
using Envision.Operational.Scanner.Common;
using WIA;

namespace Envision.Operational.Scanner
{
    public class WiaScanner
    {
        public List<ScannerDevice> ScannerDeviceList { get; set; }

        public WiaScanner() { getDevices(); }

        public List<byte[]> Scan(string deviceId, string pageSize, string colorFormat, int resolution, int brightness, int contrast)
        {
            List<byte[]> images = new List<byte[]>();

            bool has_more_page = true;

            while (has_more_page)
            {
                has_more_page = false;

                DeviceManager device_manager = new DeviceManager();
                Device device = null;

                foreach (DeviceInfo info in device_manager.DeviceInfos)
                {
                    if (info.DeviceID == deviceId)
                    {
                        device = info.Connect();
                        break;
                    }
                }

                Item item = device.Items[1];

                setValue(item.Properties, WiaScannerPropertyName.CurrentIntent, colorFormat.ToLower() == "color" ? WiaImageIntent.ColorIntent : WiaImageIntent.GrayscaleIntent);
                setValue(item.Properties, WiaScannerPropertyName.HorizontalResolution, resolution);
                setValue(item.Properties, WiaScannerPropertyName.VerticalResolution, resolution);
                setValue(item.Properties, WiaScannerPropertyName.Brightness, brightness);
                setValue(item.Properties, WiaScannerPropertyName.Contrast, contrast);

                decimal page_height = decimal.Zero;
                decimal page_width = decimal.Zero;

                switch (pageSize)
                {
                    case "A4":
                        page_height = decimal.Parse("11.69");
                        page_width = decimal.Parse("8.27");
                        break;
                }

                ScannerItem scanner_item_vertical = getItem(item.Properties, WiaScannerPropertyName.VerticalExtent);
                object default_vertical = null;

                if (scanner_item_vertical != null)
                    default_vertical = scanner_item_vertical.SubTypeMax;

                setValue(
                    item.Properties,
                    WiaScannerPropertyName.VerticalExtent,
                    page_height == decimal.Zero ? default_vertical : (int)Math.Ceiling(resolution * page_height),
                    default_vertical);

                ScannerItem scanner_item_horizontal = getItem(item.Properties, WiaScannerPropertyName.HorizontalExtent);
                object default_horizontal = null;

                if (scanner_item_horizontal != null)
                    default_horizontal = scanner_item_horizontal.SubTypeMax;

                setValue(item.Properties,
                    WiaScannerPropertyName.HorizontalExtent,
                    page_width == decimal.Zero ? default_horizontal : (int)Math.Ceiling(resolution * page_width),
                    default_horizontal);

                ImageFile image = (ImageFile)new CommonDialog().ShowTransfer(item, FormatID.wiaFormatJPEG, true);

                string file_name = Path.GetTempFileName();

                if (File.Exists(file_name))
                    File.Delete(file_name);

                images.Add((byte[])image.FileData.get_BinaryData());

                item = null;

                object obj_select = getValue(device.Properties, WiaScannerPropertyName.DocumentHandlingSelect);

                if (obj_select != null && (Convert.ToInt32(obj_select) & WiaDpsDocumentHandlingSelect.Feeder) != 0)
                {
                    object obj_status = getValue(device.Properties, WiaScannerPropertyName.DocumentHandlingStatus);

                    //if (obj_status != null && (Convert.ToInt32(obj_status) & WiaDpsDocumentHandlingStatus.FeedReady) != 0)
                    //    has_more_page = true;
                }
            }

            images.TrimExcess();

            return images;
        }

        private void getDevices()
        {
            ScannerDeviceList = new List<ScannerDevice>();

            DeviceManager device_manager = new DeviceManager();

            foreach (DeviceInfo device_info in device_manager.DeviceInfos)
            {
                if (device_info.Type != WiaDeviceType.ScannerDeviceType)
                    continue;

                try
                {
                    Device device = device_info.Connect();

                    ScannerDevice scanner_device = new ScannerDevice()
                    {
                        DeviceId = device.DeviceID,
                        Name = (getValue(device.Properties, WiaScannerPropertyName.Name) ?? device_info.DeviceID).ToString()
                    };

                    scanner_device.Items.Add(getItem(device.Items[1].Properties, WiaScannerPropertyName.HorizontalResolution));
                    scanner_device.Items.Add(getItem(device.Items[1].Properties, WiaScannerPropertyName.Brightness));
                    scanner_device.Items.Add(getItem(device.Items[1].Properties, WiaScannerPropertyName.Contrast));

                    ScannerDeviceList.Add(scanner_device);
                }
                catch { }
            }

            ScannerDeviceList.TrimExcess();
        }
        private ScannerItem getItem(IProperties properties, object name)
        {
            ScannerItem item = null;

            if (properties.Exists(ref name))
            {
                Property property = properties.get_Item(ref name);

                item = new ScannerItem()
                {
                    ItemId = property.PropertyID.ToString(),
                    Name = property.Name.Replace(" ", string.Empty),
                    IsReadOnly = property.IsReadOnly
                };

                if (!item.IsReadOnly)
                {
                    switch (property.SubType)
                    {
                        case WiaSubType.FlagSubType:
                            item.SubType = ScannerItemSubType.Flag;
                            item.SubTypeDefault = Convert.ToInt32(property.SubTypeDefault);
                            break;
                        case WiaSubType.ListSubType:
                            item.SubType = ScannerItemSubType.List;
                            item.SubTypeDefault = Convert.ToInt32(property.SubTypeDefault);

                            item.SubTypeValues = new List<int>();

                            foreach (int value in property.SubTypeValues)
                                item.SubTypeValues.Add(value);
                            break;
                        case WiaSubType.RangeSubType:
                            item.SubType = ScannerItemSubType.Range;
                            item.SubTypeDefault = Convert.ToInt32(property.SubTypeDefault);
                            item.SubTypeMax = property.SubTypeMax;
                            item.SubTypeMin = property.SubTypeMin;
                            item.SubTypeStep = property.SubTypeStep;
                            break;
                        case WiaSubType.UnspecifiedSubType:
                        default:
                            item.SubType = ScannerItemSubType.Unspecified;
                            item.IsReadOnly = true;
                            break;
                    }
                }
            }

            return item;
        }
        private object getValue(IProperties properties, object name)
        {
            object result = null;

            try
            {
                if (properties.Exists(ref name))
                    result = properties.get_Item(ref name).get_Value();
            }
            catch { }

            return result;
        }
        private void setValue(IProperties properties, object name, object value) { setValue(properties, name, value, null); }
        private void setValue(IProperties properties, object name, object value, object defaultValue)
        {
            try
            {
                if (properties.Exists(ref name))
                {
                    IProperty property = properties.get_Item(ref name);

                    if (!property.IsReadOnly)
                    {
                        try
                        {
                            property.set_Value(ref value);
                        }
                        catch
                        {
                            if (defaultValue == null)
                                defaultValue = property.SubTypeDefault;

                            property.set_Value(ref defaultValue);
                        }
                    }
                }
            }
            catch { }
        }
    }
}