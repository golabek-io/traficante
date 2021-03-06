﻿using System;
using System.Linq;
using Traficante.TSQL.Evaluator.Visitors;

namespace Traficante.TSQL.Parser.Nodes
{
    public class SelectNode : Node
    {
        public SelectNode(TopNode top, FieldNode[] fields)
        {
            Fields = fields;
            Top = top;
            var fieldsId = fields.Length == 0 ? string.Empty : fields.Select(f => f.Id).Aggregate((a, b) => a + b);
            Id = $"{nameof(SelectNode)}{fieldsId}";
        }

        public FieldNode[] Fields { get; }
        public TopNode Top { get; }

        public override Type ReturnType { get; }

        public override string Id { get; }

        public override void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            var fieldsTxt = Fields.Length == 0
                ? string.Empty
                : Fields.Select(FieldToString).Aggregate((a, b) => $"{a}, {b}");
            var topTxt = Top != null ? $"top {Top.Value} " : "";
            return $"select {topTxt}{fieldsTxt}";
        }

        private string FieldToString(FieldNode node)
        {
            return string.IsNullOrEmpty(node.FieldName) ? node.Expression.ToString() : node.FieldName;
        }
    }
}