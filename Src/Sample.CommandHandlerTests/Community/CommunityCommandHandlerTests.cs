﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.CommandHandler.Community;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IFramework.MessageQueue.MessageFormat;
using Sample.Command;
using IFramework.Message;
using IFramework.Infrastructure.Unity.LifetimeManagers;
using IFramework.Infrastructure;
using IFramework.Config;
using IFramework.Command;

namespace Sample.CommandHandler.Community.Tests
{
    [TestClass()]
    public class CommunityCommandHandlerTests
    {
        static string _UserName;
        public CommunityCommandHandlerTests()
        {
            Configuration.Instance.UseLog4Net();

        }

        static object ExecuteCommandHandler(ICommand command)
        {
            IMessageContext commandContext = new MessageContext(command);
            PerMessageContextLifetimeManager.CurrentMessageContext = commandContext;
            var commandHandler = IoCFactory.Resolve<CommunityCommandHandler>();
            ((dynamic)commandHandler).Handle((dynamic)command);
            return commandContext.Reply;
        }

        [TestMethod()]
        public void RegisterHandleTest()
        {
            Register registerCommand = new Register { 
                 UserName = "ivan" + DateTime.Now.ToShortTimeString(),
                 Password = "1234"
            };
            var result = ExecuteCommandHandler(registerCommand);
            _UserName = registerCommand.UserName;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void ModifyHandleTest()
        {
            Modify modifyCommand = new Modify { 
                 Email = "haojie77@163.com",
                 UserName = _UserName
            };
            ExecuteCommandHandler(modifyCommand);
        }
    }
}