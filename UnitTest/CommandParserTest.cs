﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoteControlServer.Parser;
using RemoteControlServer.Definitions;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class CommandParserTest
    {
        CommandParser commandParser;

        [TestInitialize()]
        public void Initialize()
        {
            commandParser = new CommandParser();
        }

        [TestMethod]
        public void CommandParser_SimpleCommand_CorrectCommandObject()
        {
            Command command = commandParser.parseCommand("TEST_CommandName");
            Assert.AreEqual(command.getAppName(), "TEST");
            Assert.AreEqual(command.getName(), "CommandName");
            Assert.AreEqual(command.getArguments().Length, 0);
        }

        [TestMethod]
        public void CommandParser_CommandWithArgument_CorrectCommandObject()
        {
            Command command = commandParser.parseCommand("TEST_CommandName|Arg");
            Assert.AreEqual(command.getAppName(), "TEST");
            Assert.AreEqual(command.getName(), "CommandName");
            Assert.AreEqual(command.getArguments().Length, 1);
            Assert.AreEqual(command.getArguments()[0], "Arg");
        }

        [TestMethod]
        public void CommandParser_CommandWithArguments_CorrectCommandObject()
        {
            Command command = commandParser.parseCommand("TEST_CommandName|Arg1:Arg2:Arg3");
            Assert.AreEqual(command.getAppName(), "TEST");
            Assert.AreEqual(command.getName(), "CommandName");
            Assert.AreEqual(command.getArguments().Length, 3);
            Assert.AreEqual(command.getArguments()[0], "Arg1");
            Assert.AreEqual(command.getArguments()[1], "Arg2");
            Assert.AreEqual(command.getArguments()[2], "Arg3");
        }

        [TestMethod]
        public void CommandParser_MoreThanTwoCommandParts_ExceptionThrown()
        {
            try
            {
                Command command = commandParser.parseCommand("TEST_CommandName|Foo|bar");
            } 
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, "TEST_CommandName|Foo|bar");
                return;
            }
            Assert.Fail("No exception thrown");
        }

        [TestMethod]
        public void CommandParser_EmptyCommand_ExceptionThrown()
        {
            try
            {
                Command command = commandParser.parseCommand("");
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("No exception thrown");
        }

        [TestMethod]
        public void CommandParser_EmptyCommandNamePart_ExceptionThrown()
        {
            try
            {
                Command command = commandParser.parseCommand("|Arg");
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, "|Arg");
                return;
            }
            Assert.Fail("No exception thrown");
        }



        [TestMethod]
        public void CommandParser_EmptyCommandArguments_CorrectCommandObject()
        {
            Command command = commandParser.parseCommand("TEST_Name|");
            Assert.AreEqual(command.getAppName(), "TEST");
            Assert.AreEqual(command.getName(), "Name");
            Assert.AreEqual(command.getArguments().Length, 0);
        }


        [TestMethod]
        public void CommandParser_MultipleEmptyCommandArguments_ExceptionThrown()
        {
            try
            {
                Command command = commandParser.parseCommand("TEST_Name|::");
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, "TEST_Name|::");
                return;
            }
            Assert.Fail("No exception thrown");
        }

    }
}
