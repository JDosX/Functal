using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionScript
{
    #region Binary Operator Methods
    #region Addition Methods
    internal class FnMethod_Add_Int32 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Int32> Num0;
        [FnArg] protected FnObject<Int32> Num1;

        public override Int32 GetValue()
        {
            return Num0.GetValue() + Num1.GetValue();
        }
    }
    internal class FnMethod_Add_UInt32 : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<UInt32> Num0;
        [FnArg] protected FnObject<UInt32> Num1;

        public override UInt32 GetValue()
        {
            return Num0.GetValue() + Num1.GetValue();
        }
    }
    internal class FnMethod_Add_Int64 : FnMethod<Int64>
    {
        [FnArg] protected FnObject<Int64> Num0;
        [FnArg] protected FnObject<Int64> Num1;

        public override Int64 GetValue()
        {
            return Num0.GetValue() + Num1.GetValue();
        }
    }
    internal class FnMethod_Add_UInt64 : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<UInt64> Num0;
        [FnArg] protected FnObject<UInt64> Num1;

        public override UInt64 GetValue()
        {
            return Num0.GetValue() + Num1.GetValue();
        }
    }
    internal class FnMethod_Add_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Num0;
        [FnArg] protected FnObject<Single> Num1;

        public override Single GetValue()
        {
            return Num0.GetValue() + Num1.GetValue();
        }
    }
    internal class FnMethod_Add_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Num0;
        [FnArg] protected FnObject<Double> Num1;

        public override Double GetValue()
        {
            return Num0.GetValue() + Num1.GetValue();
        }
    }
    internal class FnMethod_Add_Decimal : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<Decimal> Num0;
        [FnArg] protected FnObject<Decimal> Num1;

        public override Decimal GetValue()
        {
            return Num0.GetValue() + Num1.GetValue();
        }
    }
    internal class FnMethod_Add_String : FnMethod<String>
    {
        [FnArg] protected FnObject<String> String0;
        [FnArg] protected FnObject<String> String1;

        public override String GetValue()
        {
            return String0.GetValue() + String1.GetValue();
        }
    }
    #endregion
    #region Subtraction Methods
    internal class FnMethod_Subtract_Int32 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Int32> Num0;
        [FnArg] protected FnObject<Int32> Num1;

        public override Int32 GetValue()
        {
            return Num0.GetValue() - Num1.GetValue();
        }
    }
    internal class FnMethod_Subtract_UInt32 : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<UInt32> Num0;
        [FnArg] protected FnObject<UInt32> Num1;

        public override UInt32 GetValue()
        {
            return Num0.GetValue() - Num1.GetValue();
        }
    }
    internal class FnMethod_Subtract_Int64 : FnMethod<Int64>
    {
        [FnArg] protected FnObject<Int64> Num0;
        [FnArg] protected FnObject<Int64> Num1;

        public override Int64 GetValue()
        {
            return Num0.GetValue() - Num1.GetValue();
        }
    }
    internal class FnMethod_Subtract_UInt64 : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<UInt64> Num0;
        [FnArg] protected FnObject<UInt64> Num1;

        public override UInt64 GetValue()
        {
            return Num0.GetValue() - Num1.GetValue();
        }
    }
    internal class FnMethod_Subtract_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Num0;
        [FnArg] protected FnObject<Single> Num1;

        public override Single GetValue()
        {
            return Num0.GetValue() - Num1.GetValue();
        }
    }
    internal class FnMethod_Subtract_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Num0;
        [FnArg] protected FnObject<Double> Num1;

        public override Double GetValue()
        {
            return Num0.GetValue() - Num1.GetValue();
        }
    }
    internal class FnMethod_Subtract_Decimal : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<Decimal> Num0;
        [FnArg] protected FnObject<Decimal> Num1;

        public override Decimal GetValue()
        {
            return Num0.GetValue() - Num1.GetValue();
        }
    }
    #endregion
    #region Multiplication Methods
    internal class FnMethod_Multiply_Int32 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Int32> Num0;
        [FnArg] protected FnObject<Int32> Num1;

        public override Int32 GetValue()
        {
            return Num0.GetValue() * Num1.GetValue();
        }
    }
    internal class FnMethod_Multiply_UInt32 : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<UInt32> Num0;
        [FnArg] protected FnObject<UInt32> Num1;

        public override UInt32 GetValue()
        {
            return Num0.GetValue() * Num1.GetValue();
        }
    }
    internal class FnMethod_Multiply_Int64 : FnMethod<Int64>
    {
        [FnArg] protected FnObject<Int64> Num0;
        [FnArg] protected FnObject<Int64> Num1;

        public override Int64 GetValue()
        {
            return Num0.GetValue() * Num1.GetValue();
        }
    }
    internal class FnMethod_Multiply_UInt64 : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<UInt64> Num0;
        [FnArg] protected FnObject<UInt64> Num1;

        public override UInt64 GetValue()
        {
            return Num0.GetValue() * Num1.GetValue();
        }
    }
    internal class FnMethod_Multiply_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Num0;
        [FnArg] protected FnObject<Single> Num1;

        public override Single GetValue()
        {
            return Num0.GetValue() * Num1.GetValue();
        }
    }
    internal class FnMethod_Multiply_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Num0;
        [FnArg] protected FnObject<Double> Num1;

        public override Double GetValue()
        {
            return Num0.GetValue() * Num1.GetValue();
        }

    }
    internal class FnMethod_Multiply_Decimal : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<Decimal> Num0;
        [FnArg] protected FnObject<Decimal> Num1;

        public override Decimal GetValue()
        {
            return Num0.GetValue() * Num1.GetValue();
        }

    }
    #endregion
    #region Division Methods
    internal class FnMethod_Divide_Int32 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Int32> Num0;
        [FnArg] protected FnObject<Int32> Num1;

        public override Int32 GetValue()
        {
            return Num0.GetValue() / Num1.GetValue();
        }
    }
    internal class FnMethod_Divide_UInt32 : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<UInt32> Num0;
        [FnArg] protected FnObject<UInt32> Num1;

        public override UInt32 GetValue()
        {
            return Num0.GetValue() / Num1.GetValue();
        }
    }
    internal class FnMethod_Divide_Int64 : FnMethod<Int64>
    {
        [FnArg] protected FnObject<Int64> Num0;
        [FnArg] protected FnObject<Int64> Num1;

        public override Int64 GetValue()
        {
            return Num0.GetValue() / Num1.GetValue();
        }
    }
    internal class FnMethod_Divide_UInt64 : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<UInt64> Num0;
        [FnArg] protected FnObject<UInt64> Num1;

        public override UInt64 GetValue()
        {
            return Num0.GetValue() / Num1.GetValue();
        }
    }
    internal class FnMethod_Divide_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Num0;
        [FnArg] protected FnObject<Single> Num1;

        public override Single GetValue()
        {
            return Num0.GetValue() / Num1.GetValue();
        }
    }
    internal class FnMethod_Divide_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Num0;
        [FnArg] protected FnObject<Double> Num1;

        public override Double GetValue()
        {
            return Num0.GetValue() / Num1.GetValue();
        }
    }
    internal class FnMethod_Divide_Decimal : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<Decimal> Num0;
        [FnArg] protected FnObject<Decimal> Num1;

        public override Decimal GetValue()
        {
            return Num0.GetValue() / Num1.GetValue();
        }
    }
    #endregion
    #region Mod Methods
    internal class FnMethod_Mod_Int32 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Int32> Num0;
        [FnArg] protected FnObject<Int32> Num1;

        public override Int32 GetValue()
        {
            return Num0.GetValue() % Num1.GetValue();
        }
    }
    internal class FnMethod_Mod_UInt32 : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<UInt32> Num0;
        [FnArg] protected FnObject<UInt32> Num1;

        public override UInt32 GetValue()
        {
            return Num0.GetValue() % Num1.GetValue();
        }
    }
    internal class FnMethod_Mod_Int64 : FnMethod<Int64>
    {
        [FnArg] protected FnObject<Int64> Num0;
        [FnArg] protected FnObject<Int64> Num1;

        public override Int64 GetValue()
        {
            return Num0.GetValue() % Num1.GetValue();
        }
    }
    internal class FnMethod_Mod_UInt64 : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<UInt64> Num0;
        [FnArg] protected FnObject<UInt64> Num1;

        public override UInt64 GetValue()
        {
            return Num0.GetValue() % Num1.GetValue();
        }
    }
    internal class FnMethod_Mod_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Num0;
        [FnArg] protected FnObject<Single> Num1;

        public override Single GetValue()
        {
            return Num0.GetValue() % Num1.GetValue();
        }
    }
    internal class FnMethod_Mod_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Num0;
        [FnArg] protected FnObject<Double> Num1;

        public override Double GetValue()
        {
            return Num0.GetValue() % Num1.GetValue();
        }
    }
    internal class FnMethod_Mod_Decimal : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<Decimal> Num0;
        [FnArg] protected FnObject<Decimal> Num1;

        public override Decimal GetValue()
        {
            return Num0.GetValue() % Num1.GetValue();
        }
    }
    #endregion
    #endregion
    #region Unary Operator Methods

    #region Positive
    internal class FnMethod_Positive_SByte : FnMethod<SByte>
    {
        [FnArg] protected FnObject<SByte> Num;

        public override SByte GetValue()
        {
            return Num.GetValue();
        }
    }
    internal class FnMethod_Positive_Byte : FnMethod<Byte>
    {
        [FnArg] protected FnObject<Byte> Num;

        public override Byte GetValue()
        {
            return Num.GetValue();
        }
    }
    internal class FnMethod_Positive_Int16 : FnMethod<Int16>
    {
        [FnArg] protected FnObject<Int16> Num;

        public override Int16 GetValue()
        {
            return Num.GetValue();
        }
    }
    internal class FnMethod_Positive_UInt16 : FnMethod<UInt16>
    {
        [FnArg] protected FnObject<UInt16> Num;

        public override UInt16 GetValue()
        {
            return Num.GetValue();
        }
    }
    internal class FnMethod_Positive_Int32 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Int32> Num;

        public override Int32 GetValue()
        {
            return Num.GetValue();
        }
    }
    internal class FnMethod_Positive_UInt32 : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<UInt32> Num;

        public override UInt32 GetValue()
        {
            return Num.GetValue();
        }
    }
    internal class FnMethod_Positive_Int64 : FnMethod<Int64>
    {
        [FnArg] protected FnObject<Int64> Num;

        public override Int64 GetValue()
        {
            return Num.GetValue();
        }
    }
    internal class FnMethod_Positive_UInt64 : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<UInt64> Num;

        public override UInt64 GetValue()
        {
            return Num.GetValue();
        }
    }
    internal class FnMethod_Positive_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Num;

        public override Single GetValue()
        {
            return Num.GetValue();
        }
    }
    internal class FnMethod_Positive_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Num;

        public override Double GetValue()
        {
            return Num.GetValue();
        }
    }
    internal class FnMethod_Positive_Decimal : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<Decimal> Num;

        public override Decimal GetValue()
        {
            return Num.GetValue();
        }
    }
    #endregion
    #region Negative
    #region Signed Types
    internal class FnMethod_Negative_SByte : FnMethod<SByte>
    {
        [FnArg] protected FnObject<SByte> Num;

        public override SByte GetValue()
        {
            return (SByte)(-Num.GetValue());
        }
    }
    internal class FnMethod_Negative_Int16 : FnMethod<Int16>
    {
        [FnArg] protected FnObject<Int16> Num;

        public override Int16 GetValue()
        {
            return (Int16)(-Num.GetValue());
        }
    }
    internal class FnMethod_Negative_Int32 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Int32> Num;

        public override Int32 GetValue()
        {
            return -Num.GetValue();
        }
    }
    internal class FnMethod_Negative_Int64 : FnMethod<Int64>
    {
        [FnArg] protected FnObject<Int64> Num;

        public override Int64 GetValue()
        {
            return -Num.GetValue();
        }
    }
    internal class FnMethod_Negative_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Num;

        public override Single GetValue()
        {
            return -Num.GetValue();
        }
    }
    internal class FnMethod_Negative_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Num;

        public override Double GetValue()
        {
            return -Num.GetValue();
        }
    }
    internal class FnMethod_Negative_Decimal : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<Decimal> Num;

        public override Decimal GetValue()
        {
            return -Num.GetValue();
        }
    }
    #endregion
    #region Unsigned Types
    internal class FnMethod_Negative_Byte : FnMethod<Int16>
    {
        [FnArg] protected FnObject<Byte> Num;

        public override Int16 GetValue()
        {
            return (Int16)(-Num.GetValue());
        }
    }
    internal class FnMethod_Negative_UInt16 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<UInt16> Num;

        public override Int32 GetValue()
        {
            return (Int32)(-Num.GetValue());
        }
    }
    internal class FnMethod_Negative_UInt32 : FnMethod<Int64>
    {
        [FnArg] protected FnObject<UInt32> Num;

        public override Int64 GetValue()
        {
            return (Int64)(-Num.GetValue());
        }
    }
    // There are no acceptable data types to place a negative UInt64 in
    #endregion
    #endregion
    #region Not Methods
    internal class FnMethod_Not_Boolean : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Boolean> Param;

        public override Boolean GetValue()
        {
            return !Param.GetValue();
        }
    }
    #endregion

    #endregion
    #region Casting and Conversion Methods
    #region To Byte Casting Methods
    internal class FnMethod_Cast_ToByte_FromByte : FnMethod<Byte>
    {
        [FnArg] protected FnObject<Byte> Value;

        public override Byte GetValue()
        {
            return Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToByte_FromSByte : FnMethod<Byte>
    {
        [FnArg] protected FnObject<SByte> Value;

        public override Byte GetValue()
        {
            return (Byte)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToByte_FromInt16 : FnMethod<Byte>
    {
        [FnArg] protected FnObject<Int16> Value;

        public override Byte GetValue()
        {
            return (Byte)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToByte_FromUInt16 : FnMethod<Byte>
    {
        [FnArg] protected FnObject<UInt16> Value;

        public override Byte GetValue()
        {
            return (Byte)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToByte_FromInt32 : FnMethod<Byte>
    {
        [FnArg] protected FnObject<Int32> Value;

        public override Byte GetValue()
        {
            return (Byte)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToByte_FromUInt32 : FnMethod<Byte>
    {
        [FnArg] protected FnObject<UInt32> Value;

        public override Byte GetValue()
        {
            return (Byte)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToByte_FromInt64 : FnMethod<Byte>
    {
        [FnArg] protected FnObject<Int64> Value;

        public override Byte GetValue()
        {
            return (Byte)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToByte_FromUInt64 : FnMethod<Byte>
    {
        [FnArg] protected FnObject<UInt64> Value;

        public override Byte GetValue()
        {
            return (Byte)Value.GetValue();
        }
    }

    internal class FnMethod_Cast_ToByte_FromSingle : FnMethod<Byte>
    {
        [FnArg] protected FnObject<Single> Value;

        public override Byte GetValue()
        {
            return (Byte)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToByte_FromDouble : FnMethod<Byte>
    {
        [FnArg] protected FnObject<Double> Value;

        public override Byte GetValue()
        {
            return (Byte)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToByte_FromDecimal : FnMethod<Byte>
    {
        [FnArg] protected FnObject<Decimal> Value;

        public override Byte GetValue()
        {
            return (Byte)Value.GetValue();
        }
    }

    internal class FnMethod_Cast_ToByte_FromChar : FnMethod<Byte>
    {
        [FnArg] protected FnObject<Char> Value;

        public override Byte GetValue()
        {
            return (Byte)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToByte_FromString : FnMethod<Byte>
    {
        [FnArg] protected FnObject<String> Value;

        public override Byte GetValue()
        {
            String value = Value.GetValue();
            Byte output;

            // Try casting to byte directly
            if (Byte.TryParse(value, out output))
            {
                return output;
            }

            // Else, try casting through float first
            // (allows casting from floating point string directly to byte)
            return (Byte)(float.Parse(value));
        }
    }

    internal class FnMethod_Cast_ToByte_FromObject : FnMethod<Byte>
    {
        [FnArg] protected FnObject<Object> Value;

        public override Byte GetValue()
        {
            return (Byte)Value.GetValue();
        }
    }
    #endregion
    #region To SByte Casting Methods
    internal class FnMethod_Cast_ToSByte_FromByte : FnMethod<SByte>
    {
        [FnArg] protected FnObject<Byte> Value;

        public override SByte GetValue()
        {
            return (SByte)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToSByte_FromSByte : FnMethod<SByte>
    {
        [FnArg] protected FnObject<SByte> Value;

        public override SByte GetValue()
        {
            return Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToSByte_FromInt16 : FnMethod<SByte>
    {
        [FnArg] protected FnObject<Int16> Value;

        public override SByte GetValue()
        {
            return (SByte)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToSByte_FromUInt16 : FnMethod<SByte>
    {
        [FnArg] protected FnObject<UInt16> Value;

        public override SByte GetValue()
        {
            return (SByte)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToSByte_FromInt32 : FnMethod<SByte>
    {
        [FnArg] protected FnObject<Int32> Value;

        public override SByte GetValue()
        {
            return (SByte)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToSByte_FromUInt32 : FnMethod<SByte>
    {
        [FnArg] protected FnObject<UInt32> Value;

        public override SByte GetValue()
        {
            return (SByte)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToSByte_FromInt64 : FnMethod<SByte>
    {
        [FnArg] protected FnObject<Int64> Value;

        public override SByte GetValue()
        {
            return (SByte)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToSByte_FromUInt64 : FnMethod<SByte>
    {
        [FnArg] protected FnObject<UInt64> Value;

        public override SByte GetValue()
        {
            return (SByte)Value.GetValue();
        }
    }

    internal class FnMethod_Cast_ToSByte_FromSingle : FnMethod<SByte>
    {
        [FnArg] protected FnObject<Single> Value;

        public override SByte GetValue()
        {
            return (SByte)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToSByte_FromDouble : FnMethod<SByte>
    {
        [FnArg] protected FnObject<Double> Value;

        public override SByte GetValue()
        {
            return (SByte)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToSByte_FromDecimal : FnMethod<SByte>
    {
        [FnArg] protected FnObject<Decimal> Value;

        public override SByte GetValue()
        {
            return (SByte)Value.GetValue();
        }
    }

    internal class FnMethod_Cast_ToSByte_FromChar : FnMethod<SByte>
    {
        [FnArg] protected FnObject<Char> Value;

        public override SByte GetValue()
        {
            return (SByte)Value.GetValue();
        }
    }
    internal class FnMethod_CastSByte_FromString : FnMethod<SByte>
    {
        [FnArg] protected FnObject<String> Value;

        public override SByte GetValue()
        {
            String value = Value.GetValue();
            SByte output;

            // Cast directly to SByte
            if (SByte.TryParse(value, out output))
            {
                return output;
            }

            // Cast floating point string
            return (SByte)(float.Parse(value));
        }
    }

    internal class FnMethod_CastSByte_FromObject : FnMethod<SByte>
    {
        [FnArg] protected FnObject<Object> Value;

        public override SByte GetValue()
        {
            return (SByte)Value.GetValue();
        }
    }
    #endregion
    #region To Int16 Casting Methods
    internal class FnMethod_Cast_ToInt16_FromByte : FnMethod<Int16>
    {
        [FnArg] protected FnObject<Byte> Value;

        public FnMethod_Cast_ToInt16_FromByte()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Int16 GetValue()
        {
            return (Int16)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt16_FromSByte : FnMethod<Int16>
    {
        [FnArg] protected FnObject<SByte> Value;

        public FnMethod_Cast_ToInt16_FromSByte()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Int16 GetValue()
        {
            return (Int16)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt16_FromInt16 : FnMethod<Int16>
    {
        [FnArg] protected FnObject<Int16> Value;

        public override Int16 GetValue()
        {
            return Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt16_FromUInt16 : FnMethod<Int16>
    {
        [FnArg] protected FnObject<UInt16> Value;

        public override Int16 GetValue()
        {
            return (Int16)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt16_FromInt32 : FnMethod<Int16>
    {
        [FnArg] protected FnObject<Int32> Value;

        public override Int16 GetValue()
        {
            return (Int16)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt16_FromUInt32 : FnMethod<Int16>
    {
        [FnArg] protected FnObject<UInt32> Value;

        public override Int16 GetValue()
        {
            return (Int16)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt16_FromInt64 : FnMethod<Int16>
    {
        [FnArg] protected FnObject<Int64> Value;

        public override Int16 GetValue()
        {
            return (Int16)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt16_FromUInt64 : FnMethod<Int16>
    {
        [FnArg] protected FnObject<UInt64> Value;

        public override Int16 GetValue()
        {
            return (Int16)Value.GetValue();
        }
    }

    internal class FnMethod_Cast_ToInt16_FromSingle : FnMethod<Int16>
    {
        [FnArg] protected FnObject<Single> Value;

        public override Int16 GetValue()
        {
            return (Int16)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt16_FromDouble : FnMethod<Int16>
    {
        [FnArg] protected FnObject<Double> Value;

        public override Int16 GetValue()
        {
            return (Int16)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt16_FromDecimal : FnMethod<Int16>
    {
        [FnArg] protected FnObject<Decimal> Value;

        public override Int16 GetValue()
        {
            return (Int16)Value.GetValue();
        }
    }

    internal class FnMethod_Cast_ToInt16_FromChar : FnMethod<Int16>
    {
        [FnArg] protected FnObject<Char> Value;

        public override Int16 GetValue()
        {
            return (Int16)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt16_FromString : FnMethod<Int16>
    {
        [FnArg] protected FnObject<String> Value;

        public override Int16 GetValue()
        {
            String value = Value.GetValue();
            Int16 output;

            // Cast directly to Int16
            if (Int16.TryParse(value, out output))
            {
                return output;
            }

            // Cast floating point string
            return (Int16)(float.Parse(value));
        }
    }

    internal class FnMethod_Cast_ToInt16_FromObject : FnMethod<Int16>
    {
        [FnArg] protected FnObject<Object> Value;

        public override Int16 GetValue()
        {
            return (Int16)Value.GetValue();
        }
    }
    #endregion
    #region To UInt16 Casting Methods
    internal class FnMethod_Cast_ToUInt16_FromByte : FnMethod<UInt16>
    {
        [FnArg] protected FnObject<Byte> Value;

        public FnMethod_Cast_ToUInt16_FromByte()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override UInt16 GetValue()
        {
            return (UInt16)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt16_FromSByte : FnMethod<UInt16>
    {
        [FnArg] protected FnObject<SByte> Value;

        public override UInt16 GetValue()
        {
            return (UInt16)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt16_FromInt16 : FnMethod<UInt16>
    {
        [FnArg] protected FnObject<Int16> Value;

        public override UInt16 GetValue()
        {
            return (UInt16)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt16_FromUInt16 : FnMethod<UInt16>
    {
        [FnArg] protected FnObject<UInt16> Value;

        public override UInt16 GetValue()
        {
            return Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt16_FromInt32 : FnMethod<UInt16>
    {
        [FnArg] protected FnObject<Int32> Value;

        public override UInt16 GetValue()
        {
            return (UInt16)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt16_FromUInt32 : FnMethod<UInt16>
    {
        [FnArg] protected FnObject<UInt32> Value;

        public override UInt16 GetValue()
        {
            return (UInt16)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt16_FromInt64 : FnMethod<UInt16>
    {
        [FnArg] protected FnObject<Int64> Value;

        public override UInt16 GetValue()
        {
            return (UInt16)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt16_FromUInt64 : FnMethod<UInt16>
    {
        [FnArg] protected FnObject<UInt64> Value;

        public override UInt16 GetValue()
        {
            return (UInt16)Value.GetValue();
        }
    }
                                
    internal class FnMethod_Cast_ToUInt16_FromSingle : FnMethod<UInt16>
    {
        [FnArg] protected FnObject<Single> Value;

        public override UInt16 GetValue()
        {
            return (UInt16)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt16_FromDouble : FnMethod<UInt16>
    {
        [FnArg] protected FnObject<Double> Value;

        public override UInt16 GetValue()
        {
            return (UInt16)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt16_FromDecimal : FnMethod<UInt16>
    {
        [FnArg] protected FnObject<Decimal> Value;

        public override UInt16 GetValue()
        {
            return (UInt16)Value.GetValue();
        }
    }
                                
    internal class FnMethod_Cast_ToUInt16_FromChar : FnMethod<UInt16>
    {
        [FnArg] protected FnObject<Char> Value;

        public FnMethod_Cast_ToUInt16_FromChar()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override UInt16 GetValue()
        {
            return (UInt16)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt16_FromString : FnMethod<UInt16>
    {
        [FnArg] protected FnObject<String> Value;

        public override UInt16 GetValue()
        {
            String value = Value.GetValue();
            UInt16 output;

            // Cast to UInt16
            if (UInt16.TryParse(value, out output))
            {
                return output;
            }

            // Cast floating point String
            return (UInt16)(float.Parse(value));
        }
    }
                                
    internal class FnMethod_Cast_ToUInt16_FromObject : FnMethod<UInt16>
    {
        [FnArg] protected FnObject<Object> Value;

        public override UInt16 GetValue()
        {
            return (UInt16)Value.GetValue();
        }
    }
    #endregion
    #region To Int32 Casting Methods
    internal class FnMethod_Cast_ToInt32_FromByte : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Byte> Value;

        public FnMethod_Cast_ToInt32_FromByte()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Int32 GetValue()
        {
            return (Int32)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt32_FromSByte : FnMethod<Int32>
    {
        [FnArg] protected FnObject<SByte> Value;

        public FnMethod_Cast_ToInt32_FromSByte()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Int32 GetValue()
        {
            return (Int32)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt32_FromInt16 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Int16> Value;

        public FnMethod_Cast_ToInt32_FromInt16()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Int32 GetValue()
        {
            return (Int32)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt32_FromUInt16 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<UInt16> Value;

        public FnMethod_Cast_ToInt32_FromUInt16()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION  })
        {
        }

        public override Int32 GetValue()
        {
            return (Int32)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt32_FromInt32 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Int32> Value;

        public override Int32 GetValue()
        {
            return Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt32_FromUInt32 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<UInt32> Value;

        public override Int32 GetValue()
        {
            return (Int32)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt32_FromInt64 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Int64> Value;

        public override Int32 GetValue()
        {
            return (Int32)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt32_FromUInt64 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<UInt64> Value;

        public override Int32 GetValue()
        {
            return (Int32)Value.GetValue();
        }
    }

    internal class FnMethod_Cast_ToInt32_FromSingle : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Single> Value;

        public override Int32 GetValue()
        {
            return (Int32)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt32_FromDouble : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Double> Value;

        public override Int32 GetValue()
        {
            return (Int32)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt32_FromDecimal : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Decimal> Value;

        public override Int32 GetValue()
        {
            return (Int32)Value.GetValue();
        }
    }

    internal class FnMethod_Cast_ToInt32_FromChar : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Char> Value;

        public FnMethod_Cast_ToInt32_FromChar()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Int32 GetValue()
        {
            return (Int32)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt32_FromString : FnMethod<Int32>
    {
        [FnArg] protected FnObject<String> Value;

        public override Int32 GetValue()
        {
            String value = Value.GetValue();
            Int32 output;

            // Cast to Int32
            if (Int32.TryParse(value, out output))
            {
                return output;
            }

            // Cast floating point String
            return (Int32)(float.Parse(value));
        }
    }
    
    internal class FnMethod_Cast_ToInt32_FromObject : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Object> Value;

        public override Int32 GetValue()
        {
            return (Int32)Value.GetValue();
        }
    }
    #endregion
    #region To UInt32 Casting Methods
    internal class FnMethod_Cast_ToUInt32_FromByte : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<Byte> Value;

        public FnMethod_Cast_ToUInt32_FromByte()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override UInt32 GetValue()
        {
            return (UInt32)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt32_FromSByte : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<SByte> Value;

        public override UInt32 GetValue()
        {
            return (UInt32)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt32_FromInt16 : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<Int16> Value;

        public override UInt32 GetValue()
        {
            return (UInt32)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt32_FromUInt16 : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<UInt16> Value;

        public FnMethod_Cast_ToUInt32_FromUInt16()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override UInt32 GetValue()
        {
            return (UInt32)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt32_FromInt32 : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<Int32> Value;

        public override UInt32 GetValue()
        {
            return (UInt32)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt32_FromUInt32 : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<UInt32> Value;

        public override UInt32 GetValue()
        {
            return Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt32_FromInt64 : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<Int64> Value;

        public override UInt32 GetValue()
        {
            return (UInt32)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt32_FromUInt64 : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<UInt64> Value;

        public override UInt32 GetValue()
        {
            return (UInt32)Value.GetValue();
        }
    }

    internal class FnMethod_Cast_ToUInt32_FromSingle : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<Single> Value;

        public override UInt32 GetValue()
        {
            return (UInt32)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt32_FromDouble : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<Double> Value;

        public override UInt32 GetValue()
        {
            return (UInt32)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt32_FromDecimal : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<Decimal> Value;

        public override UInt32 GetValue()
        {
            return (UInt32)Value.GetValue();
        }
    }

    internal class FnMethod_Cast_ToUInt32_FromChar : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<Char> Value;

        public FnMethod_Cast_ToUInt32_FromChar()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION  })
        {
        }

        public override UInt32 GetValue()
        {
            return (UInt32)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt32_FromString : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<String> Value;

        public override UInt32 GetValue()
        {
            String value = Value.GetValue();
            UInt32 output;

            // Cast to UInt32
            if (UInt32.TryParse(value, out output))
            {
                return output;
            }

            // Cast floating point String
            return (UInt32)(float.Parse(value));
        }
    }

    internal class FnMethod_Cast_ToUInt32_FromObject : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<Object> Value;

        public override UInt32 GetValue()
        {
            return (UInt32)Value.GetValue();
        }
    }
    #endregion
    #region To Int64 Casting Methods
    internal class FnMethod_Cast_ToInt64_FromByte : FnMethod<Int64>
    {
        [FnArg] protected FnObject<Byte> Value;

        public FnMethod_Cast_ToInt64_FromByte()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Int64 GetValue()
        {
            return (Int64)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt64_FromSByte : FnMethod<Int64>
    {
        [FnArg] protected FnObject<SByte> Value;

        public FnMethod_Cast_ToInt64_FromSByte()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Int64 GetValue()
        {
            return (Int64)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt64_FromInt16 : FnMethod<Int64>
    {
        [FnArg] protected FnObject<Int16> Value;

        public FnMethod_Cast_ToInt64_FromInt16()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Int64 GetValue()
        {
            return (Int64)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt64_FromUInt16 : FnMethod<Int64>
    {
        [FnArg] protected FnObject<UInt16> Value;

        public FnMethod_Cast_ToInt64_FromUInt16()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Int64 GetValue()
        {
            return (Int64)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt64_FromInt32 : FnMethod<Int64>
    {
        [FnArg] protected FnObject<Int32> Value;

        public FnMethod_Cast_ToInt64_FromInt32()
            : base( new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Int64 GetValue()
        {
            return (Int64)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt64_FromUInt32 : FnMethod<Int64>
    {
        [FnArg] protected FnObject<UInt32> Value;

        public FnMethod_Cast_ToInt64_FromUInt32()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Int64 GetValue()
        {
            return (Int64)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt64_FromInt64 : FnMethod<Int64>
    {
        [FnArg] protected FnObject<Int64> Value;

        public override Int64 GetValue()
        {
            return Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt64_FromUInt64 : FnMethod<Int64>
    {
        [FnArg] protected FnObject<UInt64> Value;

        public override Int64 GetValue()
        {
            return (Int64)Value.GetValue();
        }
    }

    internal class FnMethod_Cast_ToInt64_FromSingle : FnMethod<Int64>
    {
        [FnArg] protected FnObject<Single> Value;

        public override Int64 GetValue()
        {
            return (Int64)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt64_FromDouble : FnMethod<Int64>
    {
        [FnArg] protected FnObject<Double> Value;

        public override Int64 GetValue()
        {
            return (Int64)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt64_FromDecimal : FnMethod<Int64>
    {
        [FnArg] protected FnObject<Decimal> Value;

        public override Int64 GetValue()
        {
            return (Int64)Value.GetValue();
        }
    }

    internal class FnMethod_Cast_ToInt64_FromChar : FnMethod<Int64>
    {
        [FnArg] protected FnObject<Char> Value;

        public FnMethod_Cast_ToInt64_FromChar()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Int64 GetValue()
        {
            return (Int64)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToInt64_FromString : FnMethod<Int64>
    {
        [FnArg] protected FnObject<String> Value;

        public override Int64 GetValue()
        {
            String value = Value.GetValue();
            Int64 output;

            // Cast to Int64
            if (Int64.TryParse(value, out output))
            {
                return output;
            }

            // Cast floating point String
            return (Int64)(float.Parse(value));
        }
    }

    internal class FnMethod_Cast_ToInt64_FromObject : FnMethod<Int64>
    {
        [FnArg] protected FnObject<Object> Value;

        public override Int64 GetValue()
        {
            return (Int64)Value.GetValue();
        }
    }
    #endregion
    #region To UInt64 Casting Methods
    internal class FnMethod_Cast_ToUInt64_FromByte : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<Byte> Value;

        public FnMethod_Cast_ToUInt64_FromByte()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override UInt64 GetValue()
        {
            return (UInt64)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt64_FromSByte : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<SByte> Value;

        public override UInt64 GetValue()
        {
            return (UInt64)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt64_FromInt16 : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<Int16> Value;

        public override UInt64 GetValue()
        {
            return (UInt64)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt64_FromUInt16 : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<UInt16> Value;

        public FnMethod_Cast_ToUInt64_FromUInt16()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override UInt64 GetValue()
        {
            return (UInt64)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt64_FromInt32 : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<Int32> Value;

        public override UInt64 GetValue()
        {
            return (UInt64)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt64_FromUInt32 : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<UInt32> Value;

        public FnMethod_Cast_ToUInt64_FromUInt32()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override UInt64 GetValue()
        {
            return (UInt64)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt64_FromInt64 : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<Int64> Value;

        public override UInt64 GetValue()
        {
            return (UInt64)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt64_FromUInt64 : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<UInt64> Value;

        public override UInt64 GetValue()
        {
            return Value.GetValue();
        }
    }

    internal class FnMethod_Cast_ToUInt64_FromSingle : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<Single> Value;

        public override UInt64 GetValue()
        {
            return (UInt64)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt64_FromDouble : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<Double> Value;

        public override UInt64 GetValue()
        {
            return (UInt64)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt64_FromDecimal : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<Decimal> Value;

        public override UInt64 GetValue()
        {
            return (UInt64)Value.GetValue();
        }
    }

    internal class FnMethod_Cast_ToUInt64_FromChar : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<Char> Value;

        public FnMethod_Cast_ToUInt64_FromChar()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override UInt64 GetValue()
        {
            return (UInt64)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToUInt64_FromString : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<String> Value;

        public override UInt64 GetValue()
        {
            String value = Value.GetValue();
            UInt64 output;

            // Cast to UInt64
            if (UInt64.TryParse(value, out output))
            {
                return output;
            }

            // Cast floating point String
            return (UInt64)(float.Parse(value));
        }
    }

    internal class FnMethod_Cast_ToUInt64_FromObject : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<Object> Value;

        public override UInt64 GetValue()
        {
            return (UInt64)Value.GetValue();
        }
    }
    #endregion

    #region To Single Casting Methods
    internal class FnMethod_Cast_ToSingle_FromByte : FnMethod<Single>
    {
        [FnArg] protected FnObject<Byte> Value;

        public FnMethod_Cast_ToSingle_FromByte()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Single GetValue()
        {
            return (Single)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToSingle_FromSByte : FnMethod<Single>
    {
        [FnArg] protected FnObject<SByte> Value;

        public FnMethod_Cast_ToSingle_FromSByte()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Single GetValue()
        {
            return (Single)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToSingle_FromInt16 : FnMethod<Single>
    {
        [FnArg] protected FnObject<Int16> Value;

        public FnMethod_Cast_ToSingle_FromInt16()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Single GetValue()
        {
            return (Single)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToSingle_FromUInt16 : FnMethod<Single>
    {
        [FnArg] protected FnObject<UInt16> Value;

        public FnMethod_Cast_ToSingle_FromUInt16()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Single GetValue()
        {
            return (Single)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToSingle_FromInt32 : FnMethod<Single>
    {
        [FnArg] protected FnObject<Int32> Value;

        public FnMethod_Cast_ToSingle_FromInt32()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Single GetValue()
        {
            return (Single)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToSingle_FromUInt32 : FnMethod<Single>
    {
        [FnArg] protected FnObject<UInt32> Value;

        public FnMethod_Cast_ToSingle_FromUInt32()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Single GetValue()
        {
            return (Single)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToSingle_FromInt64 : FnMethod<Single>
    {
        [FnArg] protected FnObject<Int64> Value;

        public FnMethod_Cast_ToSingle_FromInt64()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Single GetValue()
        {
            return (Single)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToSingle_FromUInt64 : FnMethod<Single>
    {
        [FnArg] protected FnObject<UInt64> Value;

        public FnMethod_Cast_ToSingle_FromUInt64()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Single GetValue()
        {
            return (Single)Value.GetValue();
        }
    }

    internal class FnMethod_Cast_ToSingle_FromSingle : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Value;

        public override Single GetValue()
        {
            return Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToSingle_FromDouble : FnMethod<Single>
    {
        [FnArg] protected FnObject<Double> Value;

        public override Single GetValue()
        {
            return (Single)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToSingle_FromDecimal : FnMethod<Single>
    {
        [FnArg] protected FnObject<Decimal> Value;

        public override Single GetValue()
        {
            return (Single)Value.GetValue();
        }
    }

    internal class FnMethod_Cast_ToSingle_FromChar : FnMethod<Single>
    {
        [FnArg] protected FnObject<Char> Value;

        public FnMethod_Cast_ToSingle_FromChar()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Single GetValue()
        {
            return (Single)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToSingle_FromString : FnMethod<Single>
    {
        [FnArg] protected FnObject<String> Value;

        public override Single GetValue()
        {
            return Single.Parse(Value.GetValue());
        }
    }

    internal class FnMethod_Cast_ToSingle_FromObject : FnMethod<Single>
    {
        [FnArg] protected FnObject<Object> Value;

        public override Single GetValue()
        {
            return (Single)Value.GetValue();
        }
    }
    #endregion
    #region To Double Casting Methods
    internal class FnMethod_Cast_ToDouble_FromByte : FnMethod<Double>
    {
        [FnArg] protected FnObject<Byte> Value;

        public FnMethod_Cast_ToDouble_FromByte()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Double GetValue()
        {
            return (Double)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToDouble_FromSByte : FnMethod<Double>
    {
        [FnArg] protected FnObject<SByte> Value;

        public FnMethod_Cast_ToDouble_FromSByte()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Double GetValue()
        {
            return (Double)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToDouble_FromInt16 : FnMethod<Double>
    {
        [FnArg] protected FnObject<Int16> Value;

        public FnMethod_Cast_ToDouble_FromInt16()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Double GetValue()
        {
            return (Double)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToDouble_FromUInt16 : FnMethod<Double>
    {
        [FnArg] protected FnObject<UInt16> Value;

        public FnMethod_Cast_ToDouble_FromUInt16()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Double GetValue()
        {
            return (Double)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToDouble_FromInt32 : FnMethod<Double>
    {
        [FnArg] protected FnObject<Int32> Value;

        public FnMethod_Cast_ToDouble_FromInt32()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Double GetValue()
        {
            return (Double)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToDouble_FromUInt32 : FnMethod<Double>
    {
        [FnArg] protected FnObject<UInt32> Value;

        public FnMethod_Cast_ToDouble_FromUInt32()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Double GetValue()
        {
            return (Double)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToDouble_FromInt64 : FnMethod<Double>
    {
        [FnArg] protected FnObject<Int64> Value;

        public FnMethod_Cast_ToDouble_FromInt64()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Double GetValue()
        {
            return (Double)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToDouble_FromUInt64 : FnMethod<Double>
    {
        [FnArg] protected FnObject<UInt64> Value;

        public FnMethod_Cast_ToDouble_FromUInt64()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Double GetValue()
        {
            return (Double)Value.GetValue();
        }
    }

    internal class FnMethod_Cast_ToDouble_FromSingle : FnMethod<Double>
    {
        [FnArg] protected FnObject<Single> Value;

        public FnMethod_Cast_ToDouble_FromSingle()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Double GetValue()
        {
            return (Double)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToDouble_FromDouble : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Value;

        public override Double GetValue()
        {
            return Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToDouble_FromDecimal : FnMethod<Double>
    {
        [FnArg] protected FnObject<Decimal> Value;

        public override Double GetValue()
        {
            return (Double)Value.GetValue();
        }
    }

    internal class FnMethod_Cast_ToDouble_FromChar : FnMethod<Double>
    {
        [FnArg] protected FnObject<Char> Value;

        public FnMethod_Cast_ToDouble_FromChar()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Double GetValue()
        {
            return (Double)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToDouble_FromString : FnMethod<Double>
    {
        [FnArg] protected FnObject<String> Value;

        public override Double GetValue()
        {
            return Double.Parse(Value.GetValue());
        }
    }

    internal class FnMethod_Cast_ToDouble_FromObject : FnMethod<Double>
    {
        [FnArg] protected FnObject<Object> Value;

        public override Double GetValue()
        {
            return (Double)Value.GetValue();
        }
    }
    #endregion
    #region To Decimal Casting Methods
    internal class FnMethod_Cast_ToDecimal_FromByte : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<Byte> Value;

        public FnMethod_Cast_ToDecimal_FromByte()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Decimal GetValue()
        {
            return (Decimal)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToDecimal_FromSByte : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<SByte> Value;

        public FnMethod_Cast_ToDecimal_FromSByte()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Decimal GetValue()
        {
            return (Decimal)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToDecimal_FromInt16 : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<Int16> Value;

        public FnMethod_Cast_ToDecimal_FromInt16()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Decimal GetValue()
        {
            return (Decimal)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToDecimal_FromUInt16 : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<UInt16> Value;

        public FnMethod_Cast_ToDecimal_FromUInt16()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Decimal GetValue()
        {
            return (Decimal)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToDecimal_FromInt32 : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<Int32> Value;

        public FnMethod_Cast_ToDecimal_FromInt32()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Decimal GetValue()
        {
            return (Decimal)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToDecimal_FromUInt32 : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<UInt32> Value;

        public FnMethod_Cast_ToDecimal_FromUInt32()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Decimal GetValue()
        {
            return (Decimal)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToDecimal_FromInt64 : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<Int64> Value;

        public FnMethod_Cast_ToDecimal_FromInt64()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Decimal GetValue()
        {
            return (Decimal)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToDecimal_FromUInt64 : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<UInt64> Value;

        public FnMethod_Cast_ToDecimal_FromUInt64()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Decimal GetValue()
        {
            return (Decimal)Value.GetValue();
        }
    }
 
    internal class FnMethod_Cast_ToDecimal_FromSingle : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<Single> Value;

        public override Decimal GetValue()
        {
            return (Decimal)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToDecimal_FromDouble : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<Double> Value;

        public override Decimal GetValue()
        {
            return (Decimal)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToDecimal_FromDecimal : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<Decimal> Value;

        public override Decimal GetValue()
        {
            return Value.GetValue();
        }
    }

    internal class FnMethod_Cast_ToDecimal_FromChar : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<Char> Value;

        public FnMethod_Cast_ToDecimal_FromChar()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Decimal GetValue()
        {
            return (Decimal)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToDecimal_FromString : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<String> Value;

        public override Decimal GetValue()
        {
            return Decimal.Parse(Value.GetValue());
        }
    }

    internal class FnMethod_Cast_ToDecimal_FromObject : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<Object> Value;

        public override Decimal GetValue()
        {
            return (Decimal)Value.GetValue();
        }
    }
    #endregion
    #region To Char Casting Methods
    internal class FnMethod_Cast_ToChar_FromByte : FnMethod<Char>
    {
        [FnArg] protected FnObject<Byte> Value;

        public override Char GetValue()
        {
            return (Char)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToChar_FromSByte : FnMethod<Char>
    {
        [FnArg] protected FnObject<SByte> Value;

        public override Char GetValue()
        {
            return (Char)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToChar_FromInt16 : FnMethod<Char>
    {
        [FnArg] protected FnObject<Int16> Value;

        public override Char GetValue()
        {
            return (Char)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToChar_FromUInt16 : FnMethod<Char>
    {
        [FnArg] protected FnObject<UInt16> Value;

        public override Char GetValue()
        {
            return (Char)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToChar_FromInt32 : FnMethod<Char>
    {
        [FnArg] protected FnObject<Int32> Value;

        public override Char GetValue()
        {
            return (Char)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToChar_FromUInt32 : FnMethod<Char>
    {
        [FnArg] protected FnObject<UInt32> Value;

        public override Char GetValue()
        {
            return (Char)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToChar_FromInt64 : FnMethod<Char>
    {
        [FnArg] protected FnObject<Int64> Value;

        public override Char GetValue()
        {
            return (Char)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToChar_FromUInt64 : FnMethod<Char>
    {
        [FnArg] protected FnObject<UInt64> Value;

        public override Char GetValue()
        {
            return (Char)Value.GetValue();
        }
    }

    internal class FnMethod_Cast_ToChar_FromSingle : FnMethod<Char>
    {
        [FnArg] protected FnObject<Single> Value;

        public override Char GetValue()
        {
            return (Char)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToChar_FromDouble : FnMethod<Char>
    {
        [FnArg] protected FnObject<Double> Value;

        public override Char GetValue()
        {
            return (Char)Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToChar_FromDecimal : FnMethod<Char>
    {
        [FnArg] protected FnObject<Decimal> Value;

        public override Char GetValue()
        {
            return (Char)Value.GetValue();
        }
    }

    internal class FnMethod_Cast_ToChar_FromChar : FnMethod<Char>
    {
        [FnArg] protected FnObject<Char> Value;

        public override Char GetValue()
        {
            return Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToChar_FromString : FnMethod<Char>
    {
        [FnArg] protected FnObject<String> Value;

        public override Char GetValue()
        {
            String value = Value.GetValue();
            Char result;

            // Try casting to Char
            if (Char.TryParse(value, out result))
            {
                return result;
            }

            // Invalid String
            throw new ArgumentException("Conversion failed, casting to Char from this String is not possible", value);
        }
    }

    internal class FnMethod_Cast_ToChar_FromObject : FnMethod<Char>
    {
        [FnArg] protected FnObject<Object> Value;

        public override Char GetValue()
        {
            return (Char)Value.GetValue();
        }
    }
    #endregion

    #region To Int32? Casting Methods
    internal class FnMethod_ToNullableInt32_FromNull : FnMethod<Int32?>
    {
        [FnArg] protected FnObject<Object> Value;

        public FnMethod_ToNullableInt32_FromNull()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Int32? GetValue()
        {
            return (Int32?)(Value.GetValue());
        }
    }
    #endregion

    #region To String Casting Methods
    internal class FnMethod_Cast_ToString_FromString : FnMethod<String>
    {
        [FnArg] protected FnObject<String> Value;

        public override String GetValue()
        {
            return Value.GetValue();
        }
    }
    internal class FnMethod_Cast_ToString_FromObject : FnMethod<String>
    {
        [FnArg] protected FnObject<Object> Value;

        public override String GetValue()
        {
            return (String)Value.GetValue();
        }
    }
    #endregion

    #region ToString Methods
    internal class FnMethod_ToString<T> : FnMethod<String>
    {
        [FnArg] protected FnObject<T> Value;

        public override String GetValue()
        {
            return Value.GetValue().ToString();
        }
    }
    #endregion

    #region To Object Casting Methods
    internal class FnMethod_Cast_ToObject_FromObject : FnMethod<Object>
    {
        [FnArg] protected FnObject<Object> Value;

        public FnMethod_Cast_ToObject_FromObject()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.IMPLICIT_CONVERSION })
        {
        }

        public override Object GetValue()
        {
            return Value.GetValueAsObject();
        }
    }
    #endregion
    #endregion
    #region Comparison Methods TODO: Add XNOR
    #region IsGreaterThan Methods
    internal class FnMethod_IsGreaterThan_Byte : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Byte> LeftVal;
        [FnArg] protected FnObject<Byte> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() > RightVal.GetValue();
        }
    }
    internal class FnMethod_IsGreaterThan_SByte : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<SByte> LeftVal;
        [FnArg] protected FnObject<SByte> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() > RightVal.GetValue();
        }
    }
    internal class FnMethod_IsGreaterThan_Int16 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Int16> LeftVal;
        [FnArg] protected FnObject<Int16> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() > RightVal.GetValue();
        }
    }
    internal class FnMethod_IsGreaterThan_UInt16 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<UInt16> LeftVal;
        [FnArg] protected FnObject<UInt16> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() > RightVal.GetValue();
        }
    }
    internal class FnMethod_IsGreaterThan_Int32 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Int32> LeftVal;
        [FnArg] protected FnObject<Int32> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() > RightVal.GetValue();
        }
    }
    internal class FnMethod_IsGreaterThan_UInt32 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<UInt32> LeftVal;
        [FnArg] protected FnObject<UInt32> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() > RightVal.GetValue();
        }
    }
    internal class FnMethod_IsGreaterThan_Int64 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Int64> LeftVal;
        [FnArg] protected FnObject<Int64> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() > RightVal.GetValue();
        }
    }
    internal class FnMethod_IsGreaterThan_UInt64 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<UInt64> LeftVal;
        [FnArg] protected FnObject<UInt64> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() > RightVal.GetValue();
        }
    }
    internal class FnMethod_IsGreaterThan_Single : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Single> LeftVal;
        [FnArg] protected FnObject<Single> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() > RightVal.GetValue();
        }
    }
    internal class FnMethod_IsGreaterThan_Double : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Double> LeftVal;
        [FnArg] protected FnObject<Double> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() > RightVal.GetValue();
        }
    }
    internal class FnMethod_IsGreaterThan_Decimal : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Decimal> LeftVal;
        [FnArg] protected FnObject<Decimal> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() > RightVal.GetValue();
        }
    }

    internal class FnMethod_IsGreaterThan_Char : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Char> LeftVal;
        [FnArg] protected FnObject<Char> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() > RightVal.GetValue();
        }
    }
    #endregion
    #region IsGreaterThanOrEqual Methods
    internal class FnMethod_IsGreaterThanOrEqual_SByte : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<SByte> LeftVal;
        [FnArg] protected FnObject<SByte> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() >= RightVal.GetValue();
        }
    }
    internal class FnMethod_IsGreaterThanOrEqual_Byte : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Byte> LeftVal;
        [FnArg] protected FnObject<Byte> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() >= RightVal.GetValue();
        }
    }
    internal class FnMethod_IsGreaterThanOrEqual_Int16 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Int16> LeftVal;
        [FnArg] protected FnObject<Int16> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() >= RightVal.GetValue();
        }
    }
    internal class FnMethod_IsGreaterThanOrEqual_UInt16 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<UInt16> LeftVal;
        [FnArg] protected FnObject<UInt16> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() >= RightVal.GetValue();
        }
    }
    internal class FnMethod_IsGreaterThanOrEqual_Int32 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Int32> LeftVal;
        [FnArg] protected FnObject<Int32> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() >= RightVal.GetValue();
        }
    }
    internal class FnMethod_IsGreaterThanOrEqual_UInt32 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<UInt32> LeftVal;
        [FnArg] protected FnObject<UInt32> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() >= RightVal.GetValue();
        }
    }
    internal class FnMethod_IsGreaterThanOrEqual_Int64 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Int64> LeftVal;
        [FnArg] protected FnObject<Int64> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() >= RightVal.GetValue();
        }
    }
    internal class FnMethod_IsGreaterThanOrEqual_UInt64 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<UInt64> LeftVal;
        [FnArg] protected FnObject<UInt64> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() >= RightVal.GetValue();
        }
    }
    internal class FnMethod_IsGreaterThanOrEqual_Single : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Single> LeftVal;
        [FnArg] protected FnObject<Single> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() >= RightVal.GetValue();
        }
    }
    internal class FnMethod_IsGreaterThanOrEqual_Double : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Double> LeftVal;
        [FnArg] protected FnObject<Double> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() >= RightVal.GetValue();
        }
    }
    internal class FnMethod_IsGreaterThanOrEqual_Decimal : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Decimal> LeftVal;
        [FnArg] protected FnObject<Decimal> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() >= RightVal.GetValue();
        }
    }

    internal class FnMethod_IsGreaterThanOrEqual_Char : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Char> LeftVal;
        [FnArg] protected FnObject<Char> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() >= RightVal.GetValue();
        }
    }
    #endregion
    #region IsLessThan Methods
    internal class FnMethod_IsLessThan_Byte : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Byte> LeftVal;
        [FnArg] protected FnObject<Byte> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() < RightVal.GetValue();
        }
    }
    internal class FnMethod_IsLessThan_SByte : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<SByte> LeftVal;
        [FnArg] protected FnObject<SByte> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() < RightVal.GetValue();
        }
    }
    internal class FnMethod_IsLessThan_Int16 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Int16> LeftVal;
        [FnArg] protected FnObject<Int16> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() < RightVal.GetValue();
        }
    }
    internal class FnMethod_IsLessThan_UInt16 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<UInt16> LeftVal;
        [FnArg] protected FnObject<UInt16> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() < RightVal.GetValue();
        }
    }
    internal class FnMethod_IsLessThan_Int32 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Int32> LeftVal;
        [FnArg] protected FnObject<Int32> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() < RightVal.GetValue();
        }
    }
    internal class FnMethod_IsLessThan_UInt32 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<UInt32> LeftVal;
        [FnArg] protected FnObject<UInt32> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() < RightVal.GetValue();
        }
    }
    internal class FnMethod_IsLessThan_Int64 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Int64> LeftVal;
        [FnArg] protected FnObject<Int64> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() < RightVal.GetValue();
        }
    }
    internal class FnMethod_IsLessThan_UInt64 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<UInt64> LeftVal;
        [FnArg] protected FnObject<UInt64> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() < RightVal.GetValue();
        }
    }
    internal class FnMethod_IsLessThan_Single : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Single> LeftVal;
        [FnArg] protected FnObject<Single> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() < RightVal.GetValue();
        }
    }
    internal class FnMethod_IsLessThan_Double : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Double> LeftVal;
        [FnArg] protected FnObject<Double> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() < RightVal.GetValue();
        }
    }
    internal class FnMethod_IsLessThan_Decimal : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Decimal> LeftVal;
        [FnArg] protected FnObject<Decimal> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() < RightVal.GetValue();
        }
    }

    internal class FnMethod_IsLessThan_Char : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Char> LeftVal;
        [FnArg] protected FnObject<Char> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() < RightVal.GetValue();
        }
    }
    #endregion
    #region IsLessThanOrEqual Methods
    internal class FnMethod_IsLessThanOrEqual_Byte : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Byte> LeftVal;
        [FnArg] protected FnObject<Byte> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() <= RightVal.GetValue();
        }
    }
    internal class FnMethod_IsLessThanOrEqual_SByte : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<SByte> LeftVal;
        [FnArg] protected FnObject<SByte> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() <= RightVal.GetValue();
        }
    }
    internal class FnMethod_IsLessThanOrEqual_Int16 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Int16> LeftVal;
        [FnArg] protected FnObject<Int16> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() <= RightVal.GetValue();
        }
    }
    internal class FnMethod_IsLessThanOrEqual_UInt16 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<UInt16> LeftVal;
        [FnArg] protected FnObject<UInt16> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() <= RightVal.GetValue();
        }
    }
    internal class FnMethod_IsLessThanOrEqual_Int32 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Int32> LeftVal;
        [FnArg] protected FnObject<Int32> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() <= RightVal.GetValue();
        }
    }
    internal class FnMethod_IsLessThanOrEqual_UInt32 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<UInt32> LeftVal;
        [FnArg] protected FnObject<UInt32> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() <= RightVal.GetValue();
        }
    }
    internal class FnMethod_IsLessThanOrEqual_Int64 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Int64> LeftVal;
        [FnArg] protected FnObject<Int64> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() <= RightVal.GetValue();
        }
    }
    internal class FnMethod_IsLessThanOrEqual_UInt64 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<UInt64> LeftVal;
        [FnArg] protected FnObject<UInt64> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() <= RightVal.GetValue();
        }
    }
    internal class FnMethod_IsLessThanOrEqual_Single : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Single> LeftVal;
        [FnArg] protected FnObject<Single> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() <= RightVal.GetValue();
        }
    }
    internal class FnMethod_IsLessThanOrEqual_Double : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Double> LeftVal;
        [FnArg] protected FnObject<Double> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() <= RightVal.GetValue();
        }
    }
    internal class FnMethod_IsLessThanOrEqual_Decimal : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Decimal> LeftVal;
        [FnArg] protected FnObject<Decimal> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() <= RightVal.GetValue();
        }
    }

    internal class FnMethod_IsLessThanOrEqual_Char : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Char> LeftVal;
        [FnArg] protected FnObject<Char> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() <= RightVal.GetValue();
        }
    }
    #endregion
    #region IsEqual Methods
    internal class FnMethod_IsEqual_Byte : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Byte> LeftVal;
        [FnArg] protected FnObject<Byte> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() == RightVal.GetValue();
        }
    }
    internal class FnMethod_IsEqual_SByte : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<SByte> LeftVal;
        [FnArg] protected FnObject<SByte> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() == RightVal.GetValue();
        }
    }
    internal class FnMethod_IsEqual_Int16 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Int16> LeftVal;
        [FnArg] protected FnObject<Int16> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() == RightVal.GetValue();
        }
    }
    internal class FnMethod_IsEqual_UInt16 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<UInt16> LeftVal;
        [FnArg] protected FnObject<UInt16> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() == RightVal.GetValue();
        }
    }
    internal class FnMethod_IsEqual_Int32 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Int32> LeftVal;
        [FnArg] protected FnObject<Int32> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() == RightVal.GetValue();
        }
    }
    internal class FnMethod_IsEqual_UInt32 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<UInt32> LeftVal;
        [FnArg] protected FnObject<UInt32> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() == RightVal.GetValue();
        }
    }
    internal class FnMethod_IsEqual_Int64 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Int64> LeftVal;
        [FnArg] protected FnObject<Int64> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() == RightVal.GetValue();
        }
    }
    internal class FnMethod_IsEqual_UInt64 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<UInt64> LeftVal;
        [FnArg] protected FnObject<UInt64> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() == RightVal.GetValue();
        }
    }
    internal class FnMethod_IsEqual_Single : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Single> LeftVal;
        [FnArg] protected FnObject<Single> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() == RightVal.GetValue();
        }
    }
    internal class FnMethod_IsEqual_Double : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Double> LeftVal;
        [FnArg] protected FnObject<Double> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() == RightVal.GetValue();
        }
    }
    internal class FnMethod_IsEqual_Decimal : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Decimal> LeftVal;
        [FnArg] protected FnObject<Decimal> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() == RightVal.GetValue();
        }
    }

    internal class FnMethod_IsEqual_Char : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Char> LeftVal;
        [FnArg] protected FnObject<Char> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() == RightVal.GetValue();
        }
    }
    internal class FnMethod_IsEqual_String : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<String> LeftVal;
        [FnArg] protected FnObject<String> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() == RightVal.GetValue();
        }
    }

    internal class FnMethod_IsEqual_Boolean : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Boolean> LeftVal;
        [FnArg] protected FnObject<Boolean> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() == RightVal.GetValue();
        }
    }

    internal class FnMethod_IsEqual_Object : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Object> LeftVal;
        [FnArg] protected FnObject<Object> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() == RightVal.GetValue();
        }
    }
    #endregion
    #region IsNotEqual Methods
    internal class FnMethod_IsNotEqual_Byte : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Byte> LeftVal;
        [FnArg] protected FnObject<Byte> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() != RightVal.GetValue();
        }
    }
    internal class FnMethod_IsNotEqual_SByte : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<SByte> LeftVal;
        [FnArg] protected FnObject<SByte> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() != RightVal.GetValue();
        }
    }
    internal class FnMethod_IsNotEqual_Int16 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Int16> LeftVal;
        [FnArg] protected FnObject<Int16> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() != RightVal.GetValue();
        }
    }
    internal class FnMethod_IsNotEqual_UInt16 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<UInt16> LeftVal;
        [FnArg] protected FnObject<UInt16> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() != RightVal.GetValue();
        }
    }
    internal class FnMethod_IsNotEqual_Int32 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Int32> LeftVal;
        [FnArg] protected FnObject<Int32> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() != RightVal.GetValue();
        }
    }
    internal class FnMethod_IsNotEqual_UInt32 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<UInt32> LeftVal;
        [FnArg] protected FnObject<UInt32> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() != RightVal.GetValue();
        }
    }
    internal class FnMethod_IsNotEqual_Int64 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Int64> LeftVal;
        [FnArg] protected FnObject<Int64> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() != RightVal.GetValue();
        }
    }
    internal class FnMethod_IsNotEqual_UInt64 : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<UInt64> LeftVal;
        [FnArg] protected FnObject<UInt64> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() != RightVal.GetValue();
        }
    }
    internal class FnMethod_IsNotEqual_Single : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Single> LeftVal;
        [FnArg] protected FnObject<Single> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() != RightVal.GetValue();
        }
    }
    internal class FnMethod_IsNotEqual_Double : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Double> LeftVal;
        [FnArg] protected FnObject<Double> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() != RightVal.GetValue();
        }
    }
    internal class FnMethod_IsNotEqual_Decimal : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Decimal> LeftVal;
        [FnArg] protected FnObject<Decimal> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() != RightVal.GetValue();
        }
    }

    internal class FnMethod_IsNotEqual_Char : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Char> LeftVal;
        [FnArg] protected FnObject<Char> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() != RightVal.GetValue();
        }
    }
    internal class FnMethod_IsNotEqual_String : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<String> LeftVal;
        [FnArg] protected FnObject<String> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() != RightVal.GetValue();
        }
    }

    internal class FnMethod_IsNotEqual_Boolean : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Boolean> LeftVal;
        [FnArg] protected FnObject<Boolean> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() != RightVal.GetValue();
        }
    }

    internal class FnMethod_IsNotEqual_Object : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Object> LeftVal;
        [FnArg] protected FnObject<Object> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() != RightVal.GetValue();
        }
    }
    #endregion
    #region And Methods
    internal class FnMethod_And : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Boolean> LeftVal;
        [FnArg] protected FnObject<Boolean> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() && RightVal.GetValue();
        }
    }
    #endregion
    #region Nand Methods
    internal class FnMethod_Nand : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Boolean> LeftVal;
        [FnArg] protected FnObject<Boolean> RightVal;

        public override Boolean GetValue()
        {
            return !(LeftVal.GetValue() && RightVal.GetValue());
        }
    }
    #endregion
    #region Or Methods
    internal class FnMethod_Or : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Boolean> LeftVal;
        [FnArg] protected FnObject<Boolean> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() || RightVal.GetValue();
        }
    }
    #endregion
    #region Nor Methods
    internal class FnMethod_Nor : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Boolean> LeftVal;
        [FnArg] protected FnObject<Boolean> RightVal;

        public override Boolean GetValue()
        {
            return !(LeftVal.GetValue() || RightVal.GetValue());
        }
    }
    #endregion
    #region Xor Methods
    internal class FnMethod_Xor : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Boolean> LeftVal;
        [FnArg] protected FnObject<Boolean> RightVal;

        public override Boolean GetValue()
        {
            return LeftVal.GetValue() ^ RightVal.GetValue();
        }
    }
    #endregion
    //This is where my XNor would go, IF I HAD ONE!! (obscure Fairly Odd Parents reference) Insert when 2.5 conversion is done
    #endregion
    #region Void Method Wrappers
    // Public so people can reference it with their own types
    public class FnMethod_Return<T> : FnMethod<T>
    {
        [FnArg] protected FnObject<T> ReturnValue;
        [FnArg] protected FnObject<Object> VoidMethod;

        public override T GetValue()
        {
            // Execute the VoidMethod
            VoidMethod.GetValue();

            // Return the desired value
            return ReturnValue.GetValue();
        }
    }
    #endregion
    #region Nullable Types Helper Methods
    #region IsNull Methods
    internal class FnMethod_IsNull : FnMethod<Boolean>
    {
        [FnArg] protected FnObject<Object> Param0;

        public override Boolean GetValue()
        {
            return Param0.GetValue() == null;
        }
    }
    #endregion
    #region Nullable GetValue Methods
    // Allows you to get a value from a nullable type
    // Public so people can extend it with their own types
    public class FnMethod_GetValue<T> : FnMethod<T>
        where T : struct
    {
        //Method parameters
        [FnArg] protected FnObject<Nullable<T>> NullableObject;

        public override T GetValue()
        {
            return NullableObject.GetValue().Value;
        }
    }
    #endregion
    #endregion

    #region .Net Math Wrapper Methods
    #region Math.Abs
    internal class FnMethod_Abs_Decimal : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<Decimal> Param0;

        public override Decimal GetValue()
        {
            return Math.Abs(Param0.GetValue());
        }
    }
    internal class FnMethod_Abs_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Param0;

        public override Double GetValue()
        {
            return Math.Abs(Param0.GetValue());
        }
    }
    internal class FnMethod_Abs_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Param0;

        public override Single GetValue()
        {
            return Math.Abs(Param0.GetValue());
        }
    }

    internal class FnMethod_Abs_Int64 : FnMethod<Int64>
    {
        [FnArg] protected FnObject<Int64> Param0;

        public override Int64 GetValue()
        {
            return Math.Abs(Param0.GetValue());
        }
    }
    internal class FnMethod_Abs_Int32 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Int32> Param0;

        public override Int32 GetValue()
        {
            return Math.Abs(Param0.GetValue());
        }
    }
    internal class FnMethod_Abs_Int16 : FnMethod<Int16>
    {
        [FnArg] protected FnObject<Int16> Param0;

        public override Int16 GetValue()
        {
            return Math.Abs(Param0.GetValue());
        }
    }
    internal class FnMethod_Abs_SByte : FnMethod<SByte>
    {
        [FnArg] protected FnObject<SByte> Param0;

        public override SByte GetValue()
        {
            return Math.Abs(Param0.GetValue());
        }
    }
    #endregion
    #region Math.Acos
    internal class FnMethod_Acos_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Param0;

        public override Double GetValue()
        {
            return Math.Acos(Param0.GetValue());
        }
    }
    internal class FnMethod_Acos_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Param0;

        public override Single GetValue()
        {
            return (Single)Math.Acos(Param0.GetValue());
        }
    }
    #endregion
    #region Math.Asin
    internal class FnMethod_Asin_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Param0;

        public override Double GetValue()
        {
            return Math.Asin(Param0.GetValue());
        }
    }
    internal class FnMethod_Asin_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Param0;

        public override Single GetValue()
        {
            return (Single)Math.Asin(Param0.GetValue());
        }
    }
    #endregion
    #region Math.Atan
    internal class FnMethod_Atan_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Param0;

        public override Double GetValue()
        {
            return Math.Atan(Param0.GetValue());
        }
    }
    internal class FnMethod_Atan_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Param0;

        public override Single GetValue()
        {
            return (Single)Math.Atan(Param0.GetValue());
        }
    }
    #endregion
    #region Math.Atan2
    internal class FnMethod_Atan2_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Param0;
        [FnArg] protected FnObject<Double> Param1;

        public override Double GetValue()
        {
            return Math.Atan2(Param0.GetValue(), Param1.GetValue());
        }
    }
    internal class FnMethod_Atan2_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Param0;
        [FnArg] protected FnObject<Single> Param1;

        public override Single GetValue()
        {
            return (Single)Math.Atan2(Param0.GetValue(), Param1.GetValue());
        }
    }
    #endregion
    #region Math.Ceiling
    internal class FnMethod_Ceiling_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Param0;

        public override Double GetValue()
        {
            return Math.Ceiling(Param0.GetValue());
        }
    }
    internal class FnMethod_Ceiling_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Param0;

        public override Single GetValue()
        {
            return (Single)Math.Ceiling(Param0.GetValue());
        }
    }
    #endregion
    #region Math.Cos
    internal class FnMethod_Cos_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Param0;

        public override Double GetValue()
        {
            return Math.Cos(Param0.GetValue());
        }
    }
    internal class FnMethod_Cos_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Param0;

        public override Single GetValue()
        {
            return (Single)Math.Cos(Param0.GetValue());
        }
    }
    #endregion
    #region Math.Cosh
    internal class FnMethod_Cosh_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Param0;

        public override Double GetValue()
        {
            return Math.Cosh(Param0.GetValue());
        }
    }
    internal class FnMethod_Cosh_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Param0;

        public override Single GetValue()
        {
            return (Single)Math.Cosh(Param0.GetValue());
        }
    }
    #endregion
    #region Math.Exp
    internal class FnMethod_Exp_Int32 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Int32> Param0;

        public override Int32 GetValue()
        {
            return (Int32)Math.Exp(Param0.GetValue());
        }
    }
    internal class FnMethod_Exp_UInt32 : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<UInt32> Param0;

        public override UInt32 GetValue()
        {
            return (UInt32)Math.Exp(Param0.GetValue());
        }
    }
    internal class FnMethod_Exp_Int64 : FnMethod<Int64>
    {
        [FnArg] protected FnObject<Int64> Param0;

        public override Int64 GetValue()
        {
            return (Int64)Math.Exp(Param0.GetValue());
        }
    }
    internal class FnMethod_Exp_UInt64 : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<UInt64> Param0;

        public override UInt64 GetValue()
        {
            return (UInt64)Math.Exp(Param0.GetValue());
        }
    }
    internal class FnMethod_Exp_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Param0;

        public override Single GetValue()
        {
            return (Single)Math.Exp(Param0.GetValue());
        }
    }
    internal class FnMethod_Exp_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Param0;

        public override Double GetValue()
        {
            return Math.Exp(Param0.GetValue());
        }
    }
    #endregion
    #region Math.Floor
    internal class FnMethod_Floor_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Param0;

        public override Double GetValue()
        {
            return Math.Floor(Param0.GetValue());
        }
    }
    internal class FnMethod_Floor_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Param0;

        public override Single GetValue()
        {
            return (Single)Math.Floor(Param0.GetValue());
        }
    }
    #endregion
    #region Math.IEEERemainder
    internal class FnMethod_IEEERemainder : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Param0;
        [FnArg] protected FnObject<Double> Param1;

        public override Double GetValue()
        {
            return Math.IEEERemainder(Param0.GetValue(), Param1.GetValue());
        }
    }
    #endregion
    #region Math.Log
    internal class FnMethod_Log_BaseE_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Param0;

        public override Single GetValue()
        {
            return (Single)Math.Log(Param0.GetValue());
        }
    }
    internal class FnMethod_Log_BaseE_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Param0;

        public override Double GetValue()
        {
            return Math.Log(Param0.GetValue());
        }
    }
    internal class FnMethod_Log_CustomBase_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Param0;
        [FnArg] protected FnObject<Single> Base;

        public override Single GetValue()
        {
            return (Single)Math.Log(Param0.GetValue(), Base.GetValue());
        }
    }
    internal class FnMethod_Log_CustomBase_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Param0;
        [FnArg] protected FnObject<Double> Base;

        public override Double GetValue()
        {
            return Math.Log(Param0.GetValue(), Base.GetValue());
        }
    }
    #endregion
    #region Math.Log10
    internal class FnMethod_Log10_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Param0;

        public override Single GetValue()
        {
            return (Single)Math.Log10(Param0.GetValue());
        }
    }
    internal class FnMethod_Log10_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Param0;

        public override Double GetValue()
        {
            return Math.Log10(Param0.GetValue());
        }
    }
    #endregion
    #region Math.Max
    internal class FnMethod_Max_Byte : FnMethod<Byte>
    {
        [FnArg] protected FnObject<Byte> A;
        [FnArg] protected FnObject<Byte> B;

        public override Byte GetValue()
        {
            return Math.Max(A.GetValue(), B.GetValue());
        }
    }
    internal class FnMethod_Max_SByte : FnMethod<SByte>
    {
        [FnArg] protected FnObject<SByte> A;
        [FnArg] protected FnObject<SByte> B;

        public override SByte GetValue()
        {
            return Math.Max(A.GetValue(), B.GetValue());
        }
    }
    internal class FnMethod_Max_Int16 : FnMethod<Int16>
    {
        [FnArg] protected FnObject<Int16> A;
        [FnArg] protected FnObject<Int16> B;

        public override Int16 GetValue()
        {
            return Math.Max(A.GetValue(), B.GetValue());
        }
    }
    internal class FnMethod_Max_UInt16 : FnMethod<UInt16>
    {
        [FnArg] protected FnObject<UInt16> A;
        [FnArg] protected FnObject<UInt16> B;

        public override UInt16 GetValue()
        {
            return Math.Max(A.GetValue(), B.GetValue());
        }
    }
    internal class FnMethod_Max_Int32 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Int32> A;
        [FnArg] protected FnObject<Int32> B;

        public override Int32 GetValue()
        {
            return Math.Max(A.GetValue(), B.GetValue());
        }
    }
    internal class FnMethod_Max_UInt32 : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<UInt32> A;
        [FnArg] protected FnObject<UInt32> B;

        public override UInt32 GetValue()
        {
            return Math.Max(A.GetValue(), B.GetValue());
        }
    }
    internal class FnMethod_Max_Int64 : FnMethod<Int64>
    {
        [FnArg] protected FnObject<Int64> A;
        [FnArg] protected FnObject<Int64> B;

        public override Int64 GetValue()
        {
            return Math.Max(A.GetValue(), B.GetValue());
        }
    }
    internal class FnMethod_Max_UInt64 : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<UInt64> A;
        [FnArg] protected FnObject<UInt64> B;

        public override UInt64 GetValue()
        {
            return Math.Max(A.GetValue(), B.GetValue());
        }
    }

    internal class FnMethod_Max_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> A;
        [FnArg] protected FnObject<Single> B;

        public override Single GetValue()
        {
            return Math.Max(A.GetValue(), B.GetValue());
        }
    }
    internal class FnMethod_Max_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> A;
        [FnArg] protected FnObject<Double> B;

        public override Double GetValue()
        {
            return Math.Max(A.GetValue(), B.GetValue());
        }
    }
    internal class FnMethod_Max_Decimal : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<Decimal> A;
        [FnArg] protected FnObject<Decimal> B;

        public override Decimal GetValue()
        {
            return Math.Max(A.GetValue(), B.GetValue());
        }
    }
    #endregion
    #region Math.Min
    internal class FnMethod_Min_Byte : FnMethod<Byte>
    {
        [FnArg] protected FnObject<Byte> Param0;
        [FnArg] protected FnObject<Byte> Param1;

        public override Byte GetValue()
        {
            return Math.Min(Param0.GetValue(), Param1.GetValue());
        }
    }
    internal class FnMethod_Min_SByte : FnMethod<SByte>
    {
        [FnArg] protected FnObject<SByte> Param0;
        [FnArg] protected FnObject<SByte> Param1;

        public override SByte GetValue()
        {
            return Math.Min(Param0.GetValue(), Param1.GetValue());
        }
    }
    internal class FnMethod_Min_Int16 : FnMethod<Int16>
    {
        [FnArg] protected FnObject<Int16> Param0;
        [FnArg] protected FnObject<Int16> Param1;

        public override Int16 GetValue()
        {
            return Math.Min(Param0.GetValue(), Param1.GetValue());
        }
    }
    internal class FnMethod_Min_UInt16 : FnMethod<UInt16>
    {
        [FnArg] protected FnObject<UInt16> Param0;
        [FnArg] protected FnObject<UInt16> Param1;

        public override UInt16 GetValue()
        {
            return Math.Min(Param0.GetValue(), Param1.GetValue());
        }
    }
    internal class FnMethod_Min_Int32 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Int32> Param0;
        [FnArg] protected FnObject<Int32> Param1;

        public override Int32 GetValue()
        {
            return Math.Min(Param0.GetValue(), Param1.GetValue());
        }
    }
    internal class FnMethod_Min_UInt32 : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<UInt32> Param0;
        [FnArg] protected FnObject<UInt32> Param1;

        public override UInt32 GetValue()
        {
            return Math.Min(Param0.GetValue(), Param1.GetValue());
        }
    }
    internal class FnMethod_Min_Int64 : FnMethod<Int64>
    {
        [FnArg] protected FnObject<Int64> Param0;
        [FnArg] protected FnObject<Int64> Param1;

        public override Int64 GetValue()
        {
            return Math.Min(Param0.GetValue(), Param1.GetValue());
        }
    }
    internal class FnMethod_Min_UInt64 : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<UInt64> Param0;
        [FnArg] protected FnObject<UInt64> Param1;

        public override UInt64 GetValue()
        {
            return Math.Min(Param0.GetValue(), Param1.GetValue());
        }
    }

    internal class FnMethod_Min_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Param0;
        [FnArg] protected FnObject<Single> Param1;

        public override Single GetValue()
        {
            return Math.Min(Param0.GetValue(), Param1.GetValue());
        }
    }
    internal class FnMethod_Min_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Param0;
        [FnArg] protected FnObject<Double> Param1;

        public override Double GetValue()
        {
            return Math.Min(Param0.GetValue(), Param1.GetValue());
        }
    }
    internal class FnMethod_Min_Decimal : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<Decimal> Param0;
        [FnArg] protected FnObject<Decimal> Param1;

        public override Decimal GetValue()
        {
            return Math.Min(Param0.GetValue(), Param1.GetValue());
        }
    }
    #endregion
    #region Math.Pow
    internal class FnMethod_Pow_Int32 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Int32> Param0;
        [FnArg] protected FnObject<Int32> Param1;

        public override Int32 GetValue()
        {
            return (Int32)Math.Pow(Param0.GetValue(), Param1.GetValue());
        }
    }
    internal class FnMethod_Pow_UInt32 : FnMethod<UInt32>
    {
        [FnArg] protected FnObject<UInt32> Param0;
        [FnArg] protected FnObject<UInt32> Param1;

        public override UInt32 GetValue()
        {
            return (UInt32)Math.Pow(Param0.GetValue(), Param1.GetValue());
        }
    }
    internal class FnMethod_Pow_Int64 : FnMethod<Int64>
    {
        [FnArg] protected FnObject<Int64> Param0;
        [FnArg] protected FnObject<Int64> Param1;

        public override Int64 GetValue()
        {
            return (Int64)Math.Pow(Param0.GetValue(), Param1.GetValue());
        }
    }
    internal class FnMethod_Pow_UInt64 : FnMethod<UInt64>
    {
        [FnArg] protected FnObject<UInt64> Param0;
        [FnArg] protected FnObject<UInt64> Param1;

        public override UInt64 GetValue()
        {
            return (UInt64)Math.Pow(Param0.GetValue(), Param1.GetValue());
        }
    }
    internal class FnMethod_Pow_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Param0;
        [FnArg] protected FnObject<Single> Param1;

        public override Single GetValue()
        {
            return (Single)Math.Pow(Param0.GetValue(), Param1.GetValue());
        }
    }
    internal class FnMethod_Pow_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Param0;
        [FnArg] protected FnObject<Double> Param1;

        public override Double GetValue()
        {
            return Math.Pow(Param0.GetValue(), Param1.GetValue());
        }
    }
    #endregion
    #region Math.Round
    internal class FnMethod_Round_Single_1 : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Param0;

        public override Single GetValue()
        {
            return (Single)Math.Round(Param0.GetValue());
        }
    }
    internal class FnMethod_Round_Double_1 : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Param0;

        public override Double GetValue()
        {
            return Math.Round(Param0.GetValue());
        }
    }
    internal class FnMethod_Round_Decimal_1 : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<Decimal> Param0;

        public override Decimal GetValue()
        {
            return Math.Round(Param0.GetValue());
        }
    }

    internal class FnMethod_Round_Single_2 : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Param0;
        [FnArg] protected FnObject<Int32> Param1;

        public override Single GetValue()
        {
            return (Single)Math.Round(Param0.GetValue(), Param1.GetValue());
        }
    }
    internal class FnMethod_Round_Double_2 : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Param0;
        [FnArg] protected FnObject<Int32> Param1;

        public override Double GetValue()
        {
            return Math.Round(Param0.GetValue(), Param1.GetValue());
        }
    }
    internal class FnMethod_Round_Decimal_2 : FnMethod<Decimal>
    {
        [FnArg] protected FnObject<Decimal> Param0;
        [FnArg] protected FnObject<Int32> Param1;

        public override Decimal GetValue()
        {
            return Math.Round(Param0.GetValue(), Param1.GetValue());
        }
    }
    #endregion
    #region Math.Sign
    internal class FnMethod_Sign_SByte : FnMethod<Int32>
    {
        [FnArg] protected FnObject<SByte> Value;

        public override Int32 GetValue()
        {
            return Math.Sign(Value.GetValue());
        }
    }
    internal class FnMethod_Sign_Int16 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Int16> Value;

        public override Int32 GetValue()
        {
            return Math.Sign(Value.GetValue());
        }
    }
    internal class FnMethod_Sign_Int32 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Int32> Value;

        public override Int32 GetValue()
        {
            return Math.Sign(Value.GetValue());
        }
    }
    internal class FnMethod_Sign_Int64 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Int64> Value;

        public override Int32 GetValue()
        {
            return Math.Sign(Value.GetValue());
        }
    }
    internal class FnMethod_Sign_Single : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Single> Value;

        public override Int32 GetValue()
        {
            return Math.Sign(Value.GetValue());
        }
    }
    internal class FnMethod_Sign_Double : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Double> Value;

        public override Int32 GetValue()
        {
            return Math.Sign(Value.GetValue());
        }
    }
    internal class FnMethod_Sign_Decimal : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Decimal> Value;

        public override Int32 GetValue()
        {
            return Math.Sign(Value.GetValue());
        }
    }
    #endregion
    #region Math.Sin
    internal class FnMethod_Sin_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Value;

        public override Single GetValue()
        {
            return (Single)Math.Sin(Value.GetValue());
        }
    }
    internal class FnMethod_Sin_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Value;

        public override Double GetValue()
        {
            return Math.Sin(Value.GetValue());
        }
    }
    #endregion
    #region Math.Sinh
    internal class FnMethod_Sinh_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Value;

        public override Single GetValue()
        {
            return (Single)Math.Sinh(Value.GetValue());
        }
    }
    internal class FnMethod_Sinh_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Value;

        public override Double GetValue()
        {
            return Math.Sinh(Value.GetValue());
        }
    }
    #endregion
    #region Math.Sqrt
    internal class FnMethod_Sqrt_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Param0;

        public override Single GetValue()
        {
            return (Single)Math.Sqrt(Param0.GetValue());
        }
    }
    internal class FnMethod_Sqrt_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Param0;

        public override Double GetValue()
        {
            return Math.Sqrt(Param0.GetValue());
        }
    }
    #endregion
    #region Math.Tan
    internal class FnMethod_Tan_Single : FnMethod<Single>
    {
       [FnArg] protected FnObject<Single> Value;

        public override Single GetValue()
        {
            return (Single)Math.Tan(Value.GetValue());
        }
    }
    internal class FnMethod_Tan_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Value;

        public override Double GetValue()
        {
            return Math.Tan(Value.GetValue());
        }
    }
    #endregion
    #region Math.Tanh
    internal class FnMethod_Tanh_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Value;

        public override Single GetValue()
        {
            return (Single)Math.Tanh(Value.GetValue());
        }
    }
    internal class FnMethod_Tanh_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> Value;

        public override Double GetValue()
        {
            return Math.Tanh(Value.GetValue());
        }
    }
    #endregion
    #endregion

    #region Bezier Curve Methods
    #region Quadratic Bezier Curves
    internal class FnMethod_Bezier_Quadratic_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> P0;
        [FnArg] protected FnObject<Single> P1;
        [FnArg] protected FnObject<Single> P2;

        [FnArg] protected FnObject<Single> S;

        public override Single GetValue()
        {
            Single p0 = P0.GetValue();
            Single p1 = P1.GetValue();
            Single p2 = P2.GetValue();

            Single s = S.GetValue();

            return 
                ((1 - s) * (1 - s) * p0) + 
                (2 * (1 - s) * s * p1) + 
                (s * s * p2);
        }
    }
    internal class FnMethod_Bezier_Quadratic_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> P0;
        [FnArg] protected FnObject<Double> P1;
        [FnArg] protected FnObject<Double> P2;

        [FnArg] protected FnObject<Double> S;

        public override Double GetValue()
        {
            Double p0 = P0.GetValue();
            Double p1 = P1.GetValue();
            Double p2 = P2.GetValue();

            Double s = S.GetValue();

            return 
                ((1 - s) * (1 - s) * p0) + 
                (2 * (1 - s) * s * p1) + 
                (s * s * p2);
        }
    }
    #endregion
    #region Cubic Bezier Curves
    internal class FnMethod_Bezier_Cubic_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> P0;
        [FnArg] protected FnObject<Single> P1;
        [FnArg] protected FnObject<Single> P2;
        [FnArg] protected FnObject<Single> P3;

        [FnArg] protected FnObject<Single> S;

        public override Single GetValue()
        {
            Single p0 = P0.GetValue();
            Single p1 = P1.GetValue();
            Single p2 = P2.GetValue();
            Single p3 = P3.GetValue();

            Single s = S.GetValue();

            return 
                ((1 - s) * (1 - s) * (1 - s) * p0) + 
                (3 * (1 - s) * (1 - s) * s * p1) + 
                (3 * (1 - s) * s * s * p2) + 
                (s * s * s * p3);
        }
    }
    internal class FnMethod_Bezier_Cubic_Double : FnMethod<Double>
    {
        [FnArg] protected FnObject<Double> P0;
        [FnArg] protected FnObject<Double> P1;
        [FnArg] protected FnObject<Double> P2;
        [FnArg] protected FnObject<Double> P3;

        [FnArg] protected FnObject<Double> S;

        public override Double GetValue()
        {
            Double p0 = P0.GetValue();
            Double p1 = P1.GetValue();
            Double p2 = P2.GetValue();
            Double p3 = P3.GetValue();

            Double s = S.GetValue();

            return 
                ((1 - s) * (1 - s) * (1 - s) * p0) + 
                (3 * (1 - s) * (1 - s) * s * p1) + 
                (3 * (1 - s) * s * s * p2) + 
                (s * s * s * p3);
        }
    }
    #endregion
    #endregion

    #region Other Math Methods
    #region Cycle
    internal class FnMethod_Cycle_Int32 : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Int32> Value;

        [FnArg] protected FnObject<Int32> LowerBound;
        [FnArg] protected FnObject<Int32> UpperBound;

        public override Int32 GetValue()
        {
            Int32 value = Value.GetValue();

            Int32 lowerBound = LowerBound.GetValue();
            Int32 upperBound = UpperBound.GetValue();

            return (value - lowerBound) % (upperBound - lowerBound) + lowerBound;
        }
    }
    internal class FnMethod_Cycle_Single : FnMethod<Single>
    {
        [FnArg] protected FnObject<Single> Value;

        [FnArg] protected FnObject<Single> LowerBound;
        [FnArg] protected FnObject<Single> UpperBound;

        public override Single GetValue()
        {
            Single value = Value.GetValue();

            Single lowerBound = LowerBound.GetValue();
            Single upperBound = UpperBound.GetValue();

            return (value - lowerBound) % (upperBound - lowerBound) + lowerBound;
        }
    }
    #endregion
    #region RandomInt
    internal class FnMethod_RandomInt : FnMethod<Int32>
    {
        //The random number generator
        private Random RandomGenerator;

        public FnMethod_RandomInt()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.DO_NOT_CACHE })
        {
            RandomGenerator = new Random();
        }

        public override Int32 GetValue()
        {
            // Generate random int
            return RandomGenerator.Next();
        }
    }
    internal class FnMethod_RandomInt_Max : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Int32> MaxValue;

        // The random number generator
        private Random RandomGenerator;

        public FnMethod_RandomInt_Max()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.DO_NOT_CACHE })
        {
            RandomGenerator = new Random();
        }

        public override Int32 GetValue()
        {
            return RandomGenerator.Next(MaxValue.GetValue());
        }
    }
    internal class FnMethod_RandomInt_Min_Max : FnMethod<Int32>
    {
        [FnArg] protected FnObject<Int32> MinValue;
        [FnArg] protected FnObject<Int32> MaxValue;

        //The random number generator
        private Random RandomGenerator;

        public FnMethod_RandomInt_Min_Max()
            : base(new FnScriptResources.CompileFlags[]{ FnScriptResources.CompileFlags.DO_NOT_CACHE })
        {
            RandomGenerator = new Random();
        }

        public override Int32 GetValue()
        {
            return RandomGenerator.Next(MinValue.GetValue(), MaxValue.GetValue());
        }
    }
    #endregion
    #endregion

    #region FnObject Parameter Methods
    #region SetParameter
    internal class FnMethod_SetParameter<T> : FnMethod<Object>
    {
        [FnArg] protected FnVariable<T> Parameter;
        [FnArg] protected FnObject<T> Value;

        public FnMethod_SetParameter()
            : base(new FnScriptResources.CompileFlags[]{ FnScriptResources.CompileFlags.DO_NOT_CACHE })
        {
        }

        public override Object GetValue()
        {
            //If it's not pre-execute, apply the value to the parameter

            //PROBLEM: If "Paramter" is not an FnVariable this right now provides a very nondescript
            //exception, it will simply say there's a null reference error and point somewhere in the engine
            //Fix this with some specific error catching.
            if (!IsPreExecute.Value)
            {
                Parameter.Value = Value.GetValue();
            }

            return null;
        }
    }
    #endregion
    #endregion

    #region String Methods
    #region String Class Wrapper Methods
    #region SubString
    internal class FnMethod_SubString_StartOnly : FnMethod<String>
    {
        [FnArg] protected FnObject<String> SourceString;
        [FnArg] protected FnObject<Int32> StartIndex;

        public override String GetValue()
        {
            return SourceString.GetValue().Substring(StartIndex.GetValue());
        }
    }
    internal class FnMethod_SubString_StartAndEnd : FnMethod<String>
    {
        [FnArg] protected FnObject<String> SourceString;
        [FnArg] protected FnObject<Int32> StartIndex;
        [FnArg] protected FnObject<Int32> Length;

        public override String GetValue()
        {
            return SourceString.GetValue().Substring(StartIndex.GetValue(), Length.GetValue());
        }
    }
    #endregion
    #endregion
    #region Custom String Methods
    #region RandomString
    internal class FnMethod_RandomString_WithoutPrefix : FnMethod<String>
    {
        /// <summary>
        /// Generates the random String
        /// </summary>
        Random RandomGenerator;

        [FnArg] protected FnObject<Int32> StringLength;

        public FnMethod_RandomString_WithoutPrefix()
            : base(new FnScriptResources.CompileFlags[]{ FnScriptResources.CompileFlags.DO_NOT_CACHE })
        {
            RandomGenerator = new Random();
        }

        public override String GetValue()
        {
            //Convert arguments into parameters
            Int32 stringLength = StringLength.GetValue();

            //Our return value
            StringBuilder output = new StringBuilder("", stringLength);

            //If stringLength <= 0 then we will be returning the empty string
            for (int i = 0; i < stringLength; i++)
            {
                //the space character is at position 32 <- why did I do this?
                output[i] = (Char)(RandomGenerator.Next(33, 126));
            }

            return output.ToString();
        }
    }
    internal class FnMethod_RandomString_WithPrefix : FnMethod<String>
    {
        Random RandomGenerator;

        [FnArg] protected FnObject<Int32> StringLength;
        [FnArg] protected FnObject<String> Prefix;

        public FnMethod_RandomString_WithPrefix()
            : base(new FnScriptResources.CompileFlags[] { FnScriptResources.CompileFlags.DO_NOT_CACHE })
        {
            RandomGenerator = new Random();
        }

        public override String GetValue()
        {
            //Convert arguments into parameters
            Int32 stringLength = StringLength.GetValue();
            String prefix = Prefix.GetValue();
            StringBuilder output = new StringBuilder(prefix, stringLength);

            //If stringLength <= 0 then we will be returning the empty string
            for (int i = prefix.Length; i < stringLength; i++)
            {
                //the space character is at position 32 <- why did I do this?
                output[i] = (Char)(RandomGenerator.Next(33, 126));
            }

            return output.ToString();
        }
    }
    #endregion
    #region LengthOf
    internal class FnMethod_LengthOf : FnMethod<Int32>
    {
        [FnArg] protected FnObject<String> Input;

        public override Int32 GetValue()
        {
            return Input.GetValue().Length;
        }
    }
    #endregion
    #region CharAt
    internal class FnMethod_CharAt : FnMethod<Char>
    {
        [FnArg] protected FnObject<String> Input;
        [FnArg] protected FnObject<Int32> Index;

        public override Char GetValue()
        {
            String input = Input.GetValue();
            Int32 index = Index.GetValue();

            if (index >= 0 && index < input.Length)
            {
                return input[index];
            }
            else
            {
                throw new ArgumentException("The index specified is out of range of the string", "String: \"" + input + "\", Index: " + index.ToString());
            }
        }
    }
    #endregion
    #region Reverse
    internal class FnMethod_Reverse : FnMethod<String>
    {
        [FnArg] protected FnObject<String> Input;

        public override String GetValue()
        {
            String input = Input.GetValue();
            StringBuilder output = new StringBuilder(input.Length);
            
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = input[input.Length - 1 - i];
            }

            return output.ToString();
        }
    }
    #endregion
    #endregion
    #endregion
}