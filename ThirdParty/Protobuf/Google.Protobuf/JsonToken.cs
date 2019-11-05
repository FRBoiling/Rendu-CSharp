#region Copyright notice and license

// Protocol Buffers - Google's data interchange format
// Copyright 2008 Google Inc.  All rights reserved.
// https://developers.google.com/protocol-buffers/
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are
// met:
//
//     * Redistributions of source code must retain the above copyright
// notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above
// copyright notice, this list of conditions and the following disclaimer
// in the documentation and/or other materials provided with the
// distribution.
//     * Neither the name of Google Inc. nor the names of its
// contributors may be used to endorse or promote products derived from
// this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
// OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;

namespace Google.Protobuf
{
    internal sealed class JsonToken : IEquatable<JsonToken>
    {
        // Tokens with no value can be reused.

        // A value is a string, number, array, object, null, true or false
        // Arrays and objects have start/end
        // A document consists of a value
        // Objects are name/value sequences.

        private JsonToken(TokenType type, string stringValue = null, double numberValue = 0)
        {
            Type = type;
            StringValue = stringValue;
            NumberValue = numberValue;
        }

        internal static JsonToken Null { get; } = new JsonToken(TokenType.Null);

        internal static JsonToken False { get; } = new JsonToken(TokenType.False);

        internal static JsonToken True { get; } = new JsonToken(TokenType.True);

        internal static JsonToken StartObject { get; } = new JsonToken(TokenType.StartObject);

        internal static JsonToken EndObject { get; } = new JsonToken(TokenType.EndObject);

        internal static JsonToken StartArray { get; } = new JsonToken(TokenType.StartArray);

        internal static JsonToken EndArray { get; } = new JsonToken(TokenType.EndArray);

        internal static JsonToken EndDocument { get; } = new JsonToken(TokenType.EndDocument);

        internal TokenType Type { get; }

        internal string StringValue { get; }

        internal double NumberValue { get; }

        public bool Equals(JsonToken other)
        {
            if (ReferenceEquals(other, null)) return false;
            // Note use of other.numberValue.Equals rather than ==, so that NaN compares appropriately.
            return other.Type == Type && other.StringValue == StringValue && other.NumberValue.Equals(NumberValue);
        }

        internal static JsonToken Name(string name)
        {
            return new JsonToken(TokenType.Name, name);
        }

        internal static JsonToken Value(string value)
        {
            return new JsonToken(TokenType.StringValue, value);
        }

        internal static JsonToken Value(double value)
        {
            return new JsonToken(TokenType.Number, numberValue: value);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as JsonToken);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 31 + (int) Type;
                hash = hash * 31 + StringValue == null ? 0 : StringValue.GetHashCode();
                hash = hash * 31 + NumberValue.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            switch (Type)
            {
                case TokenType.Null:
                    return "null";
                case TokenType.True:
                    return "true";
                case TokenType.False:
                    return "false";
                case TokenType.Name:
                    return "name (" + StringValue + ")";
                case TokenType.StringValue:
                    return "value (" + StringValue + ")";
                case TokenType.Number:
                    return "number (" + NumberValue + ")";
                case TokenType.StartObject:
                    return "start-object";
                case TokenType.EndObject:
                    return "end-object";
                case TokenType.StartArray:
                    return "start-array";
                case TokenType.EndArray:
                    return "end-array";
                case TokenType.EndDocument:
                    return "end-document";
                default:
                    throw new InvalidOperationException("Token is of unknown type " + Type);
            }
        }

        internal enum TokenType
        {
            Null,
            False,
            True,
            StringValue,
            Number,
            Name,
            StartObject,
            EndObject,
            StartArray,
            EndArray,
            EndDocument
        }
    }
}