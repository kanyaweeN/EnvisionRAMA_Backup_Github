using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvisionBreastControl.Utilitys
{
    public class UndoRedo
    {
        private static Stack<object> UndoStack;
        private static Stack<object> RedoStack;
        static UndoRedo()
        {
            UndoStack = new Stack<object>();
            RedoStack = new Stack<object>();
        }
        public static void Content(object item)
        {
            UndoStack.Push(item);
        }
        public static List<object> Undo()
        {
            if(UndoStack.Count > 0)
                RedoStack.Push(UndoStack.Pop());
            return UndoStack.ToList();
        }
        public static List<object> Redo()
        {
            if(RedoStack.Count > 0)
                UndoStack.Push(RedoStack.Pop());
            return UndoStack.ToList();
        }
    }
}
