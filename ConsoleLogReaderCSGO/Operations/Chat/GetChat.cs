using ConsoleLogReaderCSGO.Base;
using ConsoleLogReaderCSGO.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLogReaderCSGO.Operations.Chat
{
    /// <summary>
    /// Class that contains public and private methods of getting and sorting chat message
    /// </summary>
    internal class GetChat
    {
        #region Methods

        /// <summary>
        /// <br>Method to iterate all provided logs or from indicated index </br>
        /// <br>Returns List of MessageConsole.</br>
        /// </summary>
        /// <param name="logs">Console logs</param>
        /// <param name="startIndex">An index that indicated a line number where iteration starts </param>
        public static List<MessageConsole> GetChats(List<LogSorted> logs, int startIndex = 0)
        {
            var chatMessages = new List<MessageConsole>();

            for (int i = startIndex; i < logs.Count; i++)
            {
                if (logs[i].LogTypeFlag == LogFlags.Chat)
                {
                    string line = logs[i].Line;
                    string user = GetUserFullName(line);

                    var messageCSGO = new MessageConsole()
                    {
                        ID = i,
                        Text = GetOnlyMessage(line),
                        IsDead = IsDead(line),
                        MessageType = GetChatType(user),
                        Location = GetLocation(ref user),
                        User = GetOnlyNickname(ref user),
                    };
                    chatMessages.Add(messageCSGO);
                }
            }
            Variables.LastIndexChat = logs.Count;
            return chatMessages;
        }
        #endregion

        #region Methods private

        /// <summary>
        /// Returns true if user in chat line was dead when wrote a message.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static bool IsDead(string line)
        {
            return line.StartsWith(Variables.MessageDead);
        }

        /// <summary>
        /// Returns string that only contains username (and if is the case, string that contains game side with map spot too).
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static string GetUserFullName(string line)
        {
            return line.Substring(0, line.IndexOf(Variables.MessageUserTextSeparator)).Replace(Variables.MessageDead, string.Empty);
        }

        /// <summary>
        /// Returns reference string that is substring for game side.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static string GetOnlyNickname(ref string line)
        {
            return line.Replace(Variables.MessageTT, string.Empty).Replace(Variables.MessageCT, string.Empty);
        }

        /// <summary>
        /// <br>Returns string that contains user message.</br>
        /// <br>Message is finding after first occurrence of " : " chars</br>
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static string GetOnlyMessage(string line)
        {
            return line[(line.IndexOf(Variables.MessageUserTextSeparator) + 3)..];
        }

        /// <summary>
        /// Returns Chat Type from provided line
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static ChatType GetChatType(string line)
        {
            return !Data.LogRegex.LogChatTeam.IsMatch(line) ? ChatType.GLOBAL
                : line.Contains(Variables.MessageTT) ? ChatType.TT
                : line.Contains(Variables.MessageCT) ? ChatType.CT
                : ChatType.GLOBAL;
        }

        /// <summary>
        /// <br>Returns string that contains user spot map</br>
        /// <br>And return reference parameter that is truncated by spot map</br>
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static string GetLocation(ref string line)
        {
            try
            {
                string result = line[line.IndexOf(Variables.MessageMapSpotSeparator)..];
                line = line.Replace(result, string.Empty);
                return result.Replace(Variables.MessageMapSpotSeparator, string.Empty);
            }
            catch(ArgumentOutOfRangeException) { return null; }
        }

        #endregion
    }
}
