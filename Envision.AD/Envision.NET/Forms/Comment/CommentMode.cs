using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.NET.Forms.Comment
{
    public enum CommentMode
    {
        Open, 
        Reply, 
        New, 
        Draft, 
        ReadOnly,
        EditSend
    }
    public enum QueryFromMode
    {
        None,
        Order,
        Schedule,
    }
    public enum LevelType
    {
        PatientLevel,
        StudyLevel,
    }
}
