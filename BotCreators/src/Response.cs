using System;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotCreators
{
    public class Response
    {
        public Response(string text)
        {
            Text = text ?? "";
        }

        public string Text { get; set; }
        public IReplyMarkup ReplyMarkup { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Response))
            {
                return false;
            }

            var other = (Response) obj;

            return Equals(other);
        }
        
        public bool Equals(Response other)
        {
            if (other == null)
            {
                return false;
            }

            if (!Text.Equals(other.Text))
            {
                return false;
            }

            return CompareKeybord(ReplyMarkup, other.ReplyMarkup);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Text?.GetHashCode() ?? 0) * 397) ^ (ReplyMarkup?.GetHashCode() ?? 0);
            }
        }

        private static bool CompareKeybord(IReplyMarkup replyMarkup, IReplyMarkup otherReplyMarkup)
        {
            if (replyMarkup == null && otherReplyMarkup == null)
            {
                return true;
            }

            if (replyMarkup == null || otherReplyMarkup == null)
            {
                return false;
            }

            if (replyMarkup.GetType() != otherReplyMarkup.GetType())
            {
                return false;
            }


            var firstButtonStringList = GetButtonStringListFromKeybord(replyMarkup);
            var secondButtonStringList = GetButtonStringListFromKeybord(otherReplyMarkup);


            return firstButtonStringList.SequenceEqual(secondButtonStringList);
        }

        private static IEnumerable<string> GetButtonStringListFromKeybord(IReplyMarkup replyMarkup)
        {
            var replyKeyboardMarkup = replyMarkup as ReplyKeyboardMarkup;
            if (replyKeyboardMarkup != null)
            {
                return
                    (from row in replyKeyboardMarkup.Keyboard from col in row select col.Text).ToList();
            }

            var inlineKeyboardMarkup = replyMarkup as InlineKeyboardMarkup;
            if (inlineKeyboardMarkup != null)
            {
                return
                    (from row in inlineKeyboardMarkup.InlineKeyboard from col in row select col.Text).ToList();
            }
             
            return new List<string>();
        }
    }
}