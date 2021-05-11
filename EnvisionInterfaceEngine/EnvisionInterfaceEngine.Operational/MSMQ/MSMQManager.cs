using System;
using System.Messaging;

namespace EnvisionInterfaceEngine.Operational.MSMQ
{
    public class MSMQManager
    {
        public const string title_log = "EnvisionInterfaceEngine.Operational.MSMQ.MSMQManager";

        public static MessageQueue Initialize(string msmqPath)
        {
            MessageQueue msmq;

            if (MessageQueue.Exists(msmqPath)) msmq = new MessageQueue(msmqPath);
            else
            {
                msmq = MessageQueue.Create(msmqPath);
                msmq.SetPermissions("Administrators", MessageQueueAccessRights.FullControl);
                msmq.SetPermissions("IIS_IUSRS", MessageQueueAccessRights.FullControl);
                msmq.SetPermissions("SYSTEM", MessageQueueAccessRights.FullControl);
            }

            return msmq;
        }

        public static bool Send(string msmqPath, string label, object body)
        {
            try
            {
                using (MessageQueue queue = Initialize(msmqPath))
                {
                    queue.DefaultPropertiesToSend.Recoverable = true;

                    using (Message message = new Message())
                    {
                        message.Recoverable = true;
                        message.Label = label;
                        message.Body = body;

                        queue.Send(message);
                        queue.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.SaveLog(title_log, "Send(string msmqPath, string label, object body)", ex.Message, true);

                return false;
            }

            return true;
        }
    }
}
