﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;

namespace Microsoft.CodeAnalysis.PopulateSwitch
{
    internal abstract class AbstractPopulateSwitchExpressionDiagnosticAnalyzer<TSwitchSyntax> :
        AbstractPopulateSwitchDiagnosticAnalyzer<ISwitchExpressionOperation, TSwitchSyntax>
        where TSwitchSyntax : SyntaxNode
    {
        protected AbstractPopulateSwitchExpressionDiagnosticAnalyzer()
            : base(IDEDiagnosticIds.PopulateSwitchExpressionDiagnosticId,
                   EnforceOnBuildValues.PopulateSwitchExpression)
        {
        }

        protected sealed override OperationKind OperationKind => OperationKind.SwitchExpression;

        protected override bool IsSwitchTypeUnknown(ISwitchExpressionOperation operation)
            => operation.Value.Type is null;

        protected sealed override ICollection<ISymbol> GetMissingEnumMembers(ISwitchExpressionOperation operation)
            => PopulateSwitchExpressionHelpers.GetMissingEnumMembers(operation);

        protected sealed override bool HasDefaultCase(ISwitchExpressionOperation operation)
            => PopulateSwitchExpressionHelpers.HasDefaultCase(operation);
    }
}
