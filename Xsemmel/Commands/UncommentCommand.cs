﻿using XSemmel.Editor;

namespace XSemmel.Commands
{
    class UncommentCommand : XSemmelCommand
    {
        protected override bool CanExecute(EditorFrame ef)
        {
            if (ef.XmlEditor == null)
            {
                return false;
            }
            return true;
        }

        protected override void Execute(EditorFrame ef)
        {
            Commenter c = new Commenter(ef.XmlEditor);
            c.Uncomment();
        }

    }
}
