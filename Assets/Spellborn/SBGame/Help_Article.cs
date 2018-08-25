using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class Help_Article : Content_Type
    {
        [FoldoutGroup("Article")]
        public string Tag = string.Empty;

        [FoldoutGroup("Article")]
        public LocalizedString Title;

        [FoldoutGroup("Article")]
        public LocalizedString Body;

        [FoldoutGroup("Article")]
        public List<Help_Article> SubArticles = new List<Help_Article>();

        public Help_Article()
        {
        }
    }
}
/*
function string GetBody() {
return Body.Text;                                                           
}
function string GetTitle() {
return Title.Text;                                                          
}
*/