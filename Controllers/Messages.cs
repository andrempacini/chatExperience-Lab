using System;
using System.Data.Common;
using Microsoft.VisualBasic;

namespace Controller
{
    class ChatMessages {
        public string text;
        
        public void setOptions (string text) {
            this.text = text;
        }
        
    }
}