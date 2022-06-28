using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Scanner
{
    public struct PointerStruct
    {
        public static PointerStruct[] GetPointerStruct() {
            PointerStruct[] p = new PointerStruct[MaxScanner];
            for (int i = 0; i < MaxScanner; i++)
            {
                p[i] = new PointerStruct();
                p[i].Bmp = IntPtr.Zero;
                p[i].Pix = IntPtr.Zero;
            }
            return p;
        }
        public static PointerStruct[] ClearPointerStruct(PointerStruct[] p)
        {
            for (int i = 0; i < MaxScanner; i++)
            {
                p[i].Bmp = IntPtr.Zero;
                p[i].Pix = IntPtr.Zero;
            }
            return p;
        }

        public static string ImageUrl { get; set; }
        public const int MaxScanner = 10;

        public IntPtr Pix { get; set; }
        public IntPtr Bmp { get; set; }
       
        
    }
}
//  =====================================================================
//              In EditScanner this Structure in DataTable
//  =====================================================================
//            ORDER_IMAGE_ID        is identity from Database
//            ,HN                   is HN
//            ,ORDER_ID             is Order ID
//            ,SCHEDULE_ID          is Schedule ID
//            ,SL_NO                is Serial number
//            ,IMAGE_NAME           is Image name
//            ,ORG_ID               is Organization ID
//            ,IS_DELETED           is Delete mean's 'Y' is delete
//            ,CREATED_BY           is creator
//            ,CREATED_ON           is date create
//            ,LAST_MODIFIED_BY     is last modify
//            ,LAST_MODIFIED_ON     is las modify date
//  =====================================================================