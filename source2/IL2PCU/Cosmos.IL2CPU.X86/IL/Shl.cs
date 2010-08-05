using System;
using CPUx86 = Cosmos.Compiler.Assembler.X86;

namespace Cosmos.IL2CPU.X86.IL
{
    [Cosmos.IL2CPU.OpCode( ILOpCode.Code.Shl )]
    public class Shl : ILOp
    {
        public Shl( Cosmos.Compiler.Assembler.Assembler aAsmblr )
            : base( aAsmblr )
        {
        }

        public override void Execute( MethodInfo aMethod, ILOpCode aOpCode )
        {
            new CPUx86.Pop { DestinationReg = CPUx86.Registers.EAX }; // shift amount
            var xStackItem_ShiftAmount = Assembler.Stack.Pop();
            new CPUx86.Pop { DestinationReg = CPUx86.Registers.EDX }; // value
            var xStackItem_Value = Assembler.Stack.Pop();
            new CPUx86.Move { DestinationReg = CPUx86.Registers.EBX, SourceValue = 0 };
            new CPUx86.Move { DestinationReg = CPUx86.Registers.CL, SourceReg = CPUx86.Registers.AL };
            new CPUx86.ShiftLeft { DestinationReg = CPUx86.Registers.EDX, SourceReg = CPUx86.Registers.CL };
            new CPUx86.Push { DestinationReg = CPUx86.Registers.EDX };
            Assembler.Stack.Push( xStackItem_Value );
        }

    }
}
