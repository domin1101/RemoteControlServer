﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Wenn der Code neu generiert wird, gehen alle Änderungen an dieser Datei verloren
// </auto-generated>
//------------------------------------------------------------------------------
namespace RemoteControlServer.Composer
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
    using Definitions;

	public class CommandComposer : ICommandComposer
    {
        private Command command;
        private int currentArgumentIndex;

        public virtual string compose(Command command_)
		{
            command = command_;
            return getNamePart() + getArgumentsPart();
		}

        private string getNamePart()
        {
            return command.getAppName() + "_" + command.getName();
        }
        

        private string getArgumentsPart()
        {
            if (command.hasArguments())
            {
                return "|" + getArguments();
            }
            else
            {
                return "";
            }
        }

        private string getArguments()
        {
            string arguments = "";
            for (currentArgumentIndex = 0; currentArgumentIndex < command.getArguments().Length; currentArgumentIndex++)
            {
                arguments += getCurrentArgument();
            }
            return arguments;
        }

        private string getCurrentArgument()
        {
            string argument = command.getArguments()[currentArgumentIndex];
            if (!isLastArgument())
            {
                argument += ":";
            }
            return argument;
        }

        private bool isLastArgument()
        {
            return currentArgumentIndex == command.getArguments().Length - 1;
        }
	}
}

