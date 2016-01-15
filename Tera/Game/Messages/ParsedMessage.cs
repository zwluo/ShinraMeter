﻿using System;
using System.Threading;

namespace Tera.Game.Messages
{
    // Base class for parsed messages
    public abstract class ParsedMessage : Message
    {
        internal ParsedMessage(TeraMessageReader reader)
            : base(reader.Message.Time, reader.Message.Direction, reader.Message.Data)
        {
            Raw = reader.Message.Payload.Array;
            OpCodeName = reader.OpCodeName;

            
            /*
            if (OpCodeName.Contains("ABNORMALITY") || OpCodeName == "S_DESPAWN_NPC")
            {
                PrintRaw();
            }
            */

            
            if (OpCodeName == "S_CREATURE_CHANGE_HP" || OpCodeName == "S_SHOW_HP" || OpCodeName.Contains("ABNORMALITY"))
            {
                PrintRaw();
            }
         //   Console.WriteLine(OpCodeName);
            
            
       
        }

        public byte[] Raw { get; protected set; }

        public string OpCodeName { get; }

        public void PrintRaw()
        {
            Console.WriteLine(OpCodeName + ": ");
            Console.WriteLine(BitConverter.ToString(Raw));
        }
    }
}