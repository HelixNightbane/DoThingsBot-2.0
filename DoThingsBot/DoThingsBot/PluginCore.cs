﻿using Decal.Adapter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DoThingsBot
{
    /// <summary>
    /// This is the main plugin class. When your plugin is loaded, Startup() is called, and when it's unloaded Shutdown() is called.
    /// </summary>
    [FriendlyName("DoThingsBot")]
    public class PluginCore : PluginBase
    {
        private static string _assemblyDirectory = null;
        private ExampleUI ui;

        /// <summary>
        /// Assembly directory containing the plugin dll
        /// </summary>
        public static string AssemblyDirectory
        {
            get
            {
                if (_assemblyDirectory == null)
                {
                    try
                    {
                        _assemblyDirectory = System.IO.Path.GetDirectoryName(typeof(PluginCore).Assembly.Location);
                    }
                    catch
                    {
                        _assemblyDirectory = Environment.CurrentDirectory;
                    }
                }
                return _assemblyDirectory;
            }
            set
            {
                _assemblyDirectory = value;
            }
        }

        /// <summary>
        /// Called when your plugin is first loaded.
        /// </summary>
        protected override void Startup()
        {
            try
            {
                // subscribe to CharacterFilter_LoginComplete event, make sure to unscribe later.
                // note: if the plugin was reloaded while ingame, this event will never trigger on the newly reloaded instance.
                CoreManager.Current.CharacterFilter.LoginComplete += CharacterFilter_LoginComplete;

                // this adds text to the chatbox. it's output is local only, other players do not see this.
                CoreManager.Current.Actions.AddChatText($"This is my new decal plugin. Startup was called. DoThingsBot", 1);

                ui = new ExampleUI();
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        protected void FilterSetup(string assemblyDirectory)
        {
            AssemblyDirectory = assemblyDirectory;
        }

        /// <summary>
        /// CharacterFilter_LoginComplete event handler.
        /// </summary>
        private void CharacterFilter_LoginComplete(object sender, EventArgs e)
        {
            // it's generally a good idea to use try/catch blocks inside of decal event handlers.
            // throwing an uncaught exception inside one will generally hard crash the client.
            try
            {
                CoreManager.Current.Actions.AddChatText($"This is my new decal plugin. CharacterFilter_LoginComplete", 1);
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        /// <summary>
        /// Called when your plugin is unloaded. Either when logging out, closing the client, or hot reloading.
        /// </summary>
        protected override void Shutdown()
        {
            try
            {
                // make sure to unsubscribe from any events we were subscribed to. Not doing so
                // can cause the old plugin to stay loaded between hot reloads.
                CoreManager.Current.CharacterFilter.LoginComplete -= CharacterFilter_LoginComplete;

                // clean up our ui view
                ui.Dispose();
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        #region logging
        /// <summary>
        /// Log an exception to log.txt in the same directory as the plugin.
        /// </summary>
        /// <param name="ex"></param>
        internal static void Log(Exception ex)
        {
            Log(ex.ToString());
        }

        /// <summary>
        /// Log a string to log.txt in the same directory as the plugin.
        /// </summary>
        /// <param name="message"></param>
        internal static void Log(string message)
        {
            try
            {
                File.AppendAllText(System.IO.Path.Combine(AssemblyDirectory, "log.txt"), $"{message}\n");

                CoreManager.Current.Actions.AddChatText(message, 1);
            }
            catch { }
        }
        #endregion // logging
    }
}
