using System;
using System.Text;

namespace FunctionScript {
  // Disabling non-assignment warning to prevent one warning being thrown per FnArg. Each FnArg will be assigned to
  // during expression compilation via reflection.
  #pragma warning disable 0649

  #region Binary Operator Functions
  #region Addition Functions
  internal class FnFunction_Add_Int32 : FnFunction<Int32> {
    [FnArg] protected FnObject<Int32> Num0;
    [FnArg] protected FnObject<Int32> Num1;

    public override Int32 GetValue() {
      return Num0.GetValue() + Num1.GetValue();
    }
  }
  internal class FnFunction_Add_UInt32 : FnFunction<UInt32> {
    [FnArg] protected FnObject<UInt32> Num0;
    [FnArg] protected FnObject<UInt32> Num1;

    public override UInt32 GetValue() {
      return Num0.GetValue() + Num1.GetValue();
    }
  }
  internal class FnFunction_Add_Int64 : FnFunction<Int64> {
    [FnArg] protected FnObject<Int64> Num0;
    [FnArg] protected FnObject<Int64> Num1;

    public override Int64 GetValue() {
      return Num0.GetValue() + Num1.GetValue();
    }
  }
  internal class FnFunction_Add_UInt64 : FnFunction<UInt64> {
    [FnArg] protected FnObject<UInt64> Num0;
    [FnArg] protected FnObject<UInt64> Num1;

    public override UInt64 GetValue() {
      return Num0.GetValue() + Num1.GetValue();
    }
  }
  internal class FnFunction_Add_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Num0;
    [FnArg] protected FnObject<Single> Num1;

    public override Single GetValue() {
      return Num0.GetValue() + Num1.GetValue();
    }
  }
  internal class FnFunction_Add_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Num0;
    [FnArg] protected FnObject<Double> Num1;

    public override Double GetValue() {
      return Num0.GetValue() + Num1.GetValue();
    }
  }
  internal class FnFunction_Add_Decimal : FnFunction<Decimal> {
    [FnArg] protected FnObject<Decimal> Num0;
    [FnArg] protected FnObject<Decimal> Num1;

    public override Decimal GetValue() {
      return Num0.GetValue() + Num1.GetValue();
    }
  }
  internal class FnFunction_Add_String : FnFunction<String> {
    [FnArg] protected FnObject<String> String0;
    [FnArg] protected FnObject<String> String1;

    public override String GetValue() {
      return String0.GetValue() + String1.GetValue();
    }
  }
  #endregion
  #region Subtraction Functions
  internal class FnFunction_Subtract_Int32 : FnFunction<Int32> {
    [FnArg] protected FnObject<Int32> Num0;
    [FnArg] protected FnObject<Int32> Num1;

    public override Int32 GetValue() {
      return Num0.GetValue() - Num1.GetValue();
    }
  }
  internal class FnFunction_Subtract_UInt32 : FnFunction<UInt32> {
    [FnArg] protected FnObject<UInt32> Num0;
    [FnArg] protected FnObject<UInt32> Num1;

    public override UInt32 GetValue() {
      return Num0.GetValue() - Num1.GetValue();
    }
  }
  internal class FnFunction_Subtract_Int64 : FnFunction<Int64> {
    [FnArg] protected FnObject<Int64> Num0;
    [FnArg] protected FnObject<Int64> Num1;

    public override Int64 GetValue() {
      return Num0.GetValue() - Num1.GetValue();
    }
  }
  internal class FnFunction_Subtract_UInt64 : FnFunction<UInt64> {
    [FnArg] protected FnObject<UInt64> Num0;
    [FnArg] protected FnObject<UInt64> Num1;

    public override UInt64 GetValue() {
      return Num0.GetValue() - Num1.GetValue();
    }
  }
  internal class FnFunction_Subtract_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Num0;
    [FnArg] protected FnObject<Single> Num1;

    public override Single GetValue() {
      return Num0.GetValue() - Num1.GetValue();
    }
  }
  internal class FnFunction_Subtract_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Num0;
    [FnArg] protected FnObject<Double> Num1;

    public override Double GetValue() {
      return Num0.GetValue() - Num1.GetValue();
    }
  }
  internal class FnFunction_Subtract_Decimal : FnFunction<Decimal> {
    [FnArg] protected FnObject<Decimal> Num0;
    [FnArg] protected FnObject<Decimal> Num1;

    public override Decimal GetValue() {
      return Num0.GetValue() - Num1.GetValue();
    }
  }
  #endregion
  #region Multiplication Functions
  internal class FnFunction_Multiply_Int32 : FnFunction<Int32> {
    [FnArg] protected FnObject<Int32> Num0;
    [FnArg] protected FnObject<Int32> Num1;

    public override Int32 GetValue() {
      return Num0.GetValue() * Num1.GetValue();
    }
  }
  internal class FnFunction_Multiply_UInt32 : FnFunction<UInt32> {
    [FnArg] protected FnObject<UInt32> Num0;
    [FnArg] protected FnObject<UInt32> Num1;

    public override UInt32 GetValue() {
      return Num0.GetValue() * Num1.GetValue();
    }
  }
  internal class FnFunction_Multiply_Int64 : FnFunction<Int64> {
    [FnArg] protected FnObject<Int64> Num0;
    [FnArg] protected FnObject<Int64> Num1;

    public override Int64 GetValue() {
      return Num0.GetValue() * Num1.GetValue();
    }
  }
  internal class FnFunction_Multiply_UInt64 : FnFunction<UInt64> {
    [FnArg] protected FnObject<UInt64> Num0;
    [FnArg] protected FnObject<UInt64> Num1;

    public override UInt64 GetValue() {
      return Num0.GetValue() * Num1.GetValue();
    }
  }
  internal class FnFunction_Multiply_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Num0;
    [FnArg] protected FnObject<Single> Num1;

    public override Single GetValue() {
      return Num0.GetValue() * Num1.GetValue();
    }
  }
  internal class FnFunction_Multiply_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Num0;
    [FnArg] protected FnObject<Double> Num1;

    public override Double GetValue() {
      return Num0.GetValue() * Num1.GetValue();
    }

  }
  internal class FnFunction_Multiply_Decimal : FnFunction<Decimal> {
    [FnArg] protected FnObject<Decimal> Num0;
    [FnArg] protected FnObject<Decimal> Num1;

    public override Decimal GetValue() {
      return Num0.GetValue() * Num1.GetValue();
    }

  }
  #endregion
  #region Division Functions
  internal class FnFunction_Divide_Int32 : FnFunction<Int32> {
    [FnArg] protected FnObject<Int32> Num0;
    [FnArg] protected FnObject<Int32> Num1;

    public override Int32 GetValue() {
      return Num0.GetValue() / Num1.GetValue();
    }
  }
  internal class FnFunction_Divide_UInt32 : FnFunction<UInt32> {
    [FnArg] protected FnObject<UInt32> Num0;
    [FnArg] protected FnObject<UInt32> Num1;

    public override UInt32 GetValue() {
      return Num0.GetValue() / Num1.GetValue();
    }
  }
  internal class FnFunction_Divide_Int64 : FnFunction<Int64> {
    [FnArg] protected FnObject<Int64> Num0;
    [FnArg] protected FnObject<Int64> Num1;

    public override Int64 GetValue() {
      return Num0.GetValue() / Num1.GetValue();
    }
  }
  internal class FnFunction_Divide_UInt64 : FnFunction<UInt64> {
    [FnArg] protected FnObject<UInt64> Num0;
    [FnArg] protected FnObject<UInt64> Num1;

    public override UInt64 GetValue() {
      return Num0.GetValue() / Num1.GetValue();
    }
  }
  internal class FnFunction_Divide_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Num0;
    [FnArg] protected FnObject<Single> Num1;

    public override Single GetValue() {
      return Num0.GetValue() / Num1.GetValue();
    }
  }
  internal class FnFunction_Divide_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Num0;
    [FnArg] protected FnObject<Double> Num1;

    public override Double GetValue() {
      return Num0.GetValue() / Num1.GetValue();
    }
  }
  internal class FnFunction_Divide_Decimal : FnFunction<Decimal> {
    [FnArg] protected FnObject<Decimal> Num0;
    [FnArg] protected FnObject<Decimal> Num1;

    public override Decimal GetValue() {
      return Num0.GetValue() / Num1.GetValue();
    }
  }
  #endregion
  #region Mod Functions
  internal class FnFunction_Mod_Int32 : FnFunction<Int32> {
    [FnArg] protected FnObject<Int32> Num0;
    [FnArg] protected FnObject<Int32> Num1;

    public override Int32 GetValue() {
      return Num0.GetValue() % Num1.GetValue();
    }
  }
  internal class FnFunction_Mod_UInt32 : FnFunction<UInt32> {
    [FnArg] protected FnObject<UInt32> Num0;
    [FnArg] protected FnObject<UInt32> Num1;

    public override UInt32 GetValue() {
      return Num0.GetValue() % Num1.GetValue();
    }
  }
  internal class FnFunction_Mod_Int64 : FnFunction<Int64> {
    [FnArg] protected FnObject<Int64> Num0;
    [FnArg] protected FnObject<Int64> Num1;

    public override Int64 GetValue() {
      return Num0.GetValue() % Num1.GetValue();
    }
  }
  internal class FnFunction_Mod_UInt64 : FnFunction<UInt64> {
    [FnArg] protected FnObject<UInt64> Num0;
    [FnArg] protected FnObject<UInt64> Num1;

    public override UInt64 GetValue() {
      return Num0.GetValue() % Num1.GetValue();
    }
  }
  internal class FnFunction_Mod_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Num0;
    [FnArg] protected FnObject<Single> Num1;

    public override Single GetValue() {
      return Num0.GetValue() % Num1.GetValue();
    }
  }
  internal class FnFunction_Mod_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Num0;
    [FnArg] protected FnObject<Double> Num1;

    public override Double GetValue() {
      return Num0.GetValue() % Num1.GetValue();
    }
  }
  internal class FnFunction_Mod_Decimal : FnFunction<Decimal> {
    [FnArg] protected FnObject<Decimal> Num0;
    [FnArg] protected FnObject<Decimal> Num1;

    public override Decimal GetValue() {
      return Num0.GetValue() % Num1.GetValue();
    }
  }
  #endregion
  #endregion
  #region Unary Operator Functions

  #region Positive
  internal class FnFunction_Positive_SByte : FnFunction<SByte> {
    [FnArg] protected FnObject<SByte> Num;

    public override SByte GetValue() {
      return Num.GetValue();
    }
  }
  internal class FnFunction_Positive_Byte : FnFunction<Byte> {
    [FnArg] protected FnObject<Byte> Num;

    public override Byte GetValue() {
      return Num.GetValue();
    }
  }
  internal class FnFunction_Positive_Int16 : FnFunction<Int16> {
    [FnArg] protected FnObject<Int16> Num;

    public override Int16 GetValue() {
      return Num.GetValue();
    }
  }
  internal class FnFunction_Positive_UInt16 : FnFunction<UInt16> {
    [FnArg] protected FnObject<UInt16> Num;

    public override UInt16 GetValue() {
      return Num.GetValue();
    }
  }
  internal class FnFunction_Positive_Int32 : FnFunction<Int32> {
    [FnArg] protected FnObject<Int32> Num;

    public override Int32 GetValue() {
      return Num.GetValue();
    }
  }
  internal class FnFunction_Positive_UInt32 : FnFunction<UInt32> {
    [FnArg] protected FnObject<UInt32> Num;

    public override UInt32 GetValue() {
      return Num.GetValue();
    }
  }
  internal class FnFunction_Positive_Int64 : FnFunction<Int64> {
    [FnArg] protected FnObject<Int64> Num;

    public override Int64 GetValue() {
      return Num.GetValue();
    }
  }
  internal class FnFunction_Positive_UInt64 : FnFunction<UInt64> {
    [FnArg] protected FnObject<UInt64> Num;

    public override UInt64 GetValue() {
      return Num.GetValue();
    }
  }
  internal class FnFunction_Positive_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Num;

    public override Single GetValue() {
      return Num.GetValue();
    }
  }
  internal class FnFunction_Positive_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Num;

    public override Double GetValue() {
      return Num.GetValue();
    }
  }
  internal class FnFunction_Positive_Decimal : FnFunction<Decimal> {
    [FnArg] protected FnObject<Decimal> Num;

    public override Decimal GetValue() {
      return Num.GetValue();
    }
  }
  #endregion
  #region Negative
  #region Signed Types
  internal class FnFunction_Negative_SByte : FnFunction<SByte> {
    [FnArg] protected FnObject<SByte> Num;

    public override SByte GetValue() {
      return (SByte)(-Num.GetValue());
    }
  }
  internal class FnFunction_Negative_Int16 : FnFunction<Int16> {
    [FnArg] protected FnObject<Int16> Num;

    public override Int16 GetValue() {
      return (Int16)(-Num.GetValue());
    }
  }
  internal class FnFunction_Negative_Int32 : FnFunction<Int32> {
    [FnArg] protected FnObject<Int32> Num;

    public override Int32 GetValue() {
      return -Num.GetValue();
    }
  }
  internal class FnFunction_Negative_Int64 : FnFunction<Int64> {
    [FnArg] protected FnObject<Int64> Num;

    public override Int64 GetValue() {
      return -Num.GetValue();
    }
  }
  internal class FnFunction_Negative_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Num;

    public override Single GetValue() {
      return -Num.GetValue();
    }
  }
  internal class FnFunction_Negative_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Num;

    public override Double GetValue() {
      return -Num.GetValue();
    }
  }
  internal class FnFunction_Negative_Decimal : FnFunction<Decimal> {
    [FnArg] protected FnObject<Decimal> Num;

    public override Decimal GetValue() {
      return -Num.GetValue();
    }
  }
  #endregion
  #region Unsigned Types
  internal class FnFunction_Negative_Byte : FnFunction<Int16> {
    [FnArg] protected FnObject<Byte> Num;

    public override Int16 GetValue() {
      return (Int16)(-Num.GetValue());
    }
  }
  internal class FnFunction_Negative_UInt16 : FnFunction<Int32> {
    [FnArg] protected FnObject<UInt16> Num;

    public override Int32 GetValue() {
      return (Int32)(-Num.GetValue());
    }
  }
  internal class FnFunction_Negative_UInt32 : FnFunction<Int64> {
    [FnArg] protected FnObject<UInt32> Num;

    public override Int64 GetValue() {
      return (Int64)(-Num.GetValue());
    }
  }
  // There are no acceptable data types to place a negative UInt64 in
  #endregion
  #endregion
  #region Not Functions
  internal class FnFunction_Not_Boolean : FnFunction<Boolean> {
    [FnArg] protected FnObject<Boolean> Param;

    public override Boolean GetValue() {
      return !Param.GetValue();
    }
  }
  #endregion

  #endregion
  #region Casting and Conversion Functions
  #region To Byte Casting Functions
  internal class FnFunction_Cast_ToByte_FromByte : FnFunction<Byte> {
    [FnArg] protected FnObject<Byte> Value;

    public override Byte GetValue() {
      return Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToByte_FromSByte : FnFunction<Byte> {
    [FnArg] protected FnObject<SByte> Value;

    public override Byte GetValue() {
      return (Byte)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToByte_FromInt16 : FnFunction<Byte> {
    [FnArg] protected FnObject<Int16> Value;

    public override Byte GetValue() {
      return (Byte)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToByte_FromUInt16 : FnFunction<Byte> {
    [FnArg] protected FnObject<UInt16> Value;

    public override Byte GetValue() {
      return (Byte)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToByte_FromInt32 : FnFunction<Byte> {
    [FnArg] protected FnObject<Int32> Value;

    public override Byte GetValue() {
      return (Byte)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToByte_FromUInt32 : FnFunction<Byte> {
    [FnArg] protected FnObject<UInt32> Value;

    public override Byte GetValue() {
      return (Byte)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToByte_FromInt64 : FnFunction<Byte> {
    [FnArg] protected FnObject<Int64> Value;

    public override Byte GetValue() {
      return (Byte)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToByte_FromUInt64 : FnFunction<Byte> {
    [FnArg] protected FnObject<UInt64> Value;

    public override Byte GetValue() {
      return (Byte)Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToByte_FromSingle : FnFunction<Byte> {
    [FnArg] protected FnObject<Single> Value;

    public override Byte GetValue() {
      return (Byte)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToByte_FromDouble : FnFunction<Byte> {
    [FnArg] protected FnObject<Double> Value;

    public override Byte GetValue() {
      return (Byte)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToByte_FromDecimal : FnFunction<Byte> {
    [FnArg] protected FnObject<Decimal> Value;

    public override Byte GetValue() {
      return (Byte)Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToByte_FromChar : FnFunction<Byte> {
    [FnArg] protected FnObject<Char> Value;

    public override Byte GetValue() {
      return (Byte)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToByte_FromString : FnFunction<Byte> {
    [FnArg] protected FnObject<String> Value;

    public override Byte GetValue() {
      String value = Value.GetValue();
      Byte output;

      // Try casting to byte directly
      if (Byte.TryParse(value, out output)) {
        return output;
      }

      // Else, try casting through float first
      // (allows casting from floating point string directly to byte)
      return (Byte)(float.Parse(value));
    }
  }

  internal class FnFunction_Cast_ToByte_FromObject : FnFunction<Byte> {
    [FnArg] protected FnObject<Object> Value;

    public override Byte GetValue() {
      return (Byte)Value.GetValue();
    }
  }
  #endregion
  #region To SByte Casting Functions
  internal class FnFunction_Cast_ToSByte_FromByte : FnFunction<SByte> {
    [FnArg] protected FnObject<Byte> Value;

    public override SByte GetValue() {
      return (SByte)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToSByte_FromSByte : FnFunction<SByte> {
    [FnArg] protected FnObject<SByte> Value;

    public override SByte GetValue() {
      return Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToSByte_FromInt16 : FnFunction<SByte> {
    [FnArg] protected FnObject<Int16> Value;

    public override SByte GetValue() {
      return (SByte)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToSByte_FromUInt16 : FnFunction<SByte> {
    [FnArg] protected FnObject<UInt16> Value;

    public override SByte GetValue() {
      return (SByte)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToSByte_FromInt32 : FnFunction<SByte> {
    [FnArg] protected FnObject<Int32> Value;

    public override SByte GetValue() {
      return (SByte)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToSByte_FromUInt32 : FnFunction<SByte> {
    [FnArg] protected FnObject<UInt32> Value;

    public override SByte GetValue() {
      return (SByte)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToSByte_FromInt64 : FnFunction<SByte> {
    [FnArg] protected FnObject<Int64> Value;

    public override SByte GetValue() {
      return (SByte)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToSByte_FromUInt64 : FnFunction<SByte> {
    [FnArg] protected FnObject<UInt64> Value;

    public override SByte GetValue() {
      return (SByte)Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToSByte_FromSingle : FnFunction<SByte> {
    [FnArg] protected FnObject<Single> Value;

    public override SByte GetValue() {
      return (SByte)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToSByte_FromDouble : FnFunction<SByte> {
    [FnArg] protected FnObject<Double> Value;

    public override SByte GetValue() {
      return (SByte)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToSByte_FromDecimal : FnFunction<SByte> {
    [FnArg] protected FnObject<Decimal> Value;

    public override SByte GetValue() {
      return (SByte)Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToSByte_FromChar : FnFunction<SByte> {
    [FnArg] protected FnObject<Char> Value;

    public override SByte GetValue() {
      return (SByte)Value.GetValue();
    }
  }
  internal class FnFunction_CastSByte_FromString : FnFunction<SByte> {
    [FnArg] protected FnObject<String> Value;

    public override SByte GetValue() {
      String value = Value.GetValue();
      SByte output;

      // Cast directly to SByte
      if (SByte.TryParse(value, out output)) {
        return output;
      }

      // Cast floating point string
      return (SByte)(float.Parse(value));
    }
  }

  internal class FnFunction_CastSByte_FromObject : FnFunction<SByte> {
    [FnArg] protected FnObject<Object> Value;

    public override SByte GetValue() {
      return (SByte)Value.GetValue();
    }
  }
  #endregion
  #region To Int16 Casting Functions
  internal class FnFunction_Cast_ToInt16_FromByte : FnFunction<Int16> {
    [FnArg] protected FnObject<Byte> Value;

    public FnFunction_Cast_ToInt16_FromByte()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Int16 GetValue() {
      return (Int16)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt16_FromSByte : FnFunction<Int16> {
    [FnArg] protected FnObject<SByte> Value;

    public FnFunction_Cast_ToInt16_FromSByte()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Int16 GetValue() {
      return (Int16)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt16_FromInt16 : FnFunction<Int16> {
    [FnArg] protected FnObject<Int16> Value;

    public override Int16 GetValue() {
      return Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt16_FromUInt16 : FnFunction<Int16> {
    [FnArg] protected FnObject<UInt16> Value;

    public override Int16 GetValue() {
      return (Int16)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt16_FromInt32 : FnFunction<Int16> {
    [FnArg] protected FnObject<Int32> Value;

    public override Int16 GetValue() {
      return (Int16)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt16_FromUInt32 : FnFunction<Int16> {
    [FnArg] protected FnObject<UInt32> Value;

    public override Int16 GetValue() {
      return (Int16)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt16_FromInt64 : FnFunction<Int16> {
    [FnArg] protected FnObject<Int64> Value;

    public override Int16 GetValue() {
      return (Int16)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt16_FromUInt64 : FnFunction<Int16> {
    [FnArg] protected FnObject<UInt64> Value;

    public override Int16 GetValue() {
      return (Int16)Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToInt16_FromSingle : FnFunction<Int16> {
    [FnArg] protected FnObject<Single> Value;

    public override Int16 GetValue() {
      return (Int16)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt16_FromDouble : FnFunction<Int16> {
    [FnArg] protected FnObject<Double> Value;

    public override Int16 GetValue() {
      return (Int16)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt16_FromDecimal : FnFunction<Int16> {
    [FnArg] protected FnObject<Decimal> Value;

    public override Int16 GetValue() {
      return (Int16)Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToInt16_FromChar : FnFunction<Int16> {
    [FnArg] protected FnObject<Char> Value;

    public override Int16 GetValue() {
      return (Int16)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt16_FromString : FnFunction<Int16> {
    [FnArg] protected FnObject<String> Value;

    public override Int16 GetValue() {
      String value = Value.GetValue();
      Int16 output;

      // Cast directly to Int16
      if (Int16.TryParse(value, out output)) {
        return output;
      }

      // Cast floating point string
      return (Int16)(float.Parse(value));
    }
  }

  internal class FnFunction_Cast_ToInt16_FromObject : FnFunction<Int16> {
    [FnArg] protected FnObject<Object> Value;

    public override Int16 GetValue() {
      return (Int16)Value.GetValue();
    }
  }
  #endregion
  #region To UInt16 Casting Functions
  internal class FnFunction_Cast_ToUInt16_FromByte : FnFunction<UInt16> {
    [FnArg] protected FnObject<Byte> Value;

    public FnFunction_Cast_ToUInt16_FromByte()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override UInt16 GetValue() {
      return (UInt16)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt16_FromSByte : FnFunction<UInt16> {
    [FnArg] protected FnObject<SByte> Value;

    public override UInt16 GetValue() {
      return (UInt16)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt16_FromInt16 : FnFunction<UInt16> {
    [FnArg] protected FnObject<Int16> Value;

    public override UInt16 GetValue() {
      return (UInt16)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt16_FromUInt16 : FnFunction<UInt16> {
    [FnArg] protected FnObject<UInt16> Value;

    public override UInt16 GetValue() {
      return Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt16_FromInt32 : FnFunction<UInt16> {
    [FnArg] protected FnObject<Int32> Value;

    public override UInt16 GetValue() {
      return (UInt16)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt16_FromUInt32 : FnFunction<UInt16> {
    [FnArg] protected FnObject<UInt32> Value;

    public override UInt16 GetValue() {
      return (UInt16)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt16_FromInt64 : FnFunction<UInt16> {
    [FnArg] protected FnObject<Int64> Value;

    public override UInt16 GetValue() {
      return (UInt16)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt16_FromUInt64 : FnFunction<UInt16> {
    [FnArg] protected FnObject<UInt64> Value;

    public override UInt16 GetValue() {
      return (UInt16)Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToUInt16_FromSingle : FnFunction<UInt16> {
    [FnArg] protected FnObject<Single> Value;

    public override UInt16 GetValue() {
      return (UInt16)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt16_FromDouble : FnFunction<UInt16> {
    [FnArg] protected FnObject<Double> Value;

    public override UInt16 GetValue() {
      return (UInt16)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt16_FromDecimal : FnFunction<UInt16> {
    [FnArg] protected FnObject<Decimal> Value;

    public override UInt16 GetValue() {
      return (UInt16)Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToUInt16_FromChar : FnFunction<UInt16> {
    [FnArg] protected FnObject<Char> Value;

    public FnFunction_Cast_ToUInt16_FromChar()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override UInt16 GetValue() {
      return (UInt16)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt16_FromString : FnFunction<UInt16> {
    [FnArg] protected FnObject<String> Value;

    public override UInt16 GetValue() {
      String value = Value.GetValue();
      UInt16 output;

      // Cast to UInt16
      if (UInt16.TryParse(value, out output)) {
        return output;
      }

      // Cast floating point String
      return (UInt16)(float.Parse(value));
    }
  }

  internal class FnFunction_Cast_ToUInt16_FromObject : FnFunction<UInt16> {
    [FnArg] protected FnObject<Object> Value;

    public override UInt16 GetValue() {
      return (UInt16)Value.GetValue();
    }
  }
  #endregion
  #region To Int32 Casting Functions
  internal class FnFunction_Cast_ToInt32_FromByte : FnFunction<Int32> {
    [FnArg] protected FnObject<Byte> Value;

    public FnFunction_Cast_ToInt32_FromByte()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Int32 GetValue() {
      return (Int32)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt32_FromSByte : FnFunction<Int32> {
    [FnArg] protected FnObject<SByte> Value;

    public FnFunction_Cast_ToInt32_FromSByte()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Int32 GetValue() {
      return (Int32)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt32_FromInt16 : FnFunction<Int32> {
    [FnArg] protected FnObject<Int16> Value;

    public FnFunction_Cast_ToInt32_FromInt16()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Int32 GetValue() {
      return (Int32)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt32_FromUInt16 : FnFunction<Int32> {
    [FnArg] protected FnObject<UInt16> Value;

    public FnFunction_Cast_ToInt32_FromUInt16()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Int32 GetValue() {
      return (Int32)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt32_FromInt32 : FnFunction<Int32> {
    [FnArg] protected FnObject<Int32> Value;

    public override Int32 GetValue() {
      return Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt32_FromUInt32 : FnFunction<Int32> {
    [FnArg] protected FnObject<UInt32> Value;

    public override Int32 GetValue() {
      return (Int32)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt32_FromInt64 : FnFunction<Int32> {
    [FnArg] protected FnObject<Int64> Value;

    public override Int32 GetValue() {
      return (Int32)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt32_FromUInt64 : FnFunction<Int32> {
    [FnArg] protected FnObject<UInt64> Value;

    public override Int32 GetValue() {
      return (Int32)Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToInt32_FromSingle : FnFunction<Int32> {
    [FnArg] protected FnObject<Single> Value;

    public override Int32 GetValue() {
      return (Int32)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt32_FromDouble : FnFunction<Int32> {
    [FnArg] protected FnObject<Double> Value;

    public override Int32 GetValue() {
      return (Int32)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt32_FromDecimal : FnFunction<Int32> {
    [FnArg] protected FnObject<Decimal> Value;

    public override Int32 GetValue() {
      return (Int32)Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToInt32_FromChar : FnFunction<Int32> {
    [FnArg] protected FnObject<Char> Value;

    public FnFunction_Cast_ToInt32_FromChar()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Int32 GetValue() {
      return (Int32)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt32_FromString : FnFunction<Int32> {
    [FnArg] protected FnObject<String> Value;

    public override Int32 GetValue() {
      String value = Value.GetValue();
      Int32 output;

      // Cast to Int32
      if (Int32.TryParse(value, out output)) {
        return output;
      }

      // Cast floating point String
      return (Int32)(float.Parse(value));
    }
  }

  internal class FnFunction_Cast_ToInt32_FromObject : FnFunction<Int32> {
    [FnArg] protected FnObject<Object> Value;

    public override Int32 GetValue() {
      return (Int32)Value.GetValue();
    }
  }
  #endregion
  #region To UInt32 Casting Functions
  internal class FnFunction_Cast_ToUInt32_FromByte : FnFunction<UInt32> {
    [FnArg] protected FnObject<Byte> Value;

    public FnFunction_Cast_ToUInt32_FromByte()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override UInt32 GetValue() {
      return (UInt32)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt32_FromSByte : FnFunction<UInt32> {
    [FnArg] protected FnObject<SByte> Value;

    public override UInt32 GetValue() {
      return (UInt32)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt32_FromInt16 : FnFunction<UInt32> {
    [FnArg] protected FnObject<Int16> Value;

    public override UInt32 GetValue() {
      return (UInt32)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt32_FromUInt16 : FnFunction<UInt32> {
    [FnArg] protected FnObject<UInt16> Value;

    public FnFunction_Cast_ToUInt32_FromUInt16()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override UInt32 GetValue() {
      return (UInt32)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt32_FromInt32 : FnFunction<UInt32> {
    [FnArg] protected FnObject<Int32> Value;

    public override UInt32 GetValue() {
      return (UInt32)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt32_FromUInt32 : FnFunction<UInt32> {
    [FnArg] protected FnObject<UInt32> Value;

    public override UInt32 GetValue() {
      return Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt32_FromInt64 : FnFunction<UInt32> {
    [FnArg] protected FnObject<Int64> Value;

    public override UInt32 GetValue() {
      return (UInt32)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt32_FromUInt64 : FnFunction<UInt32> {
    [FnArg] protected FnObject<UInt64> Value;

    public override UInt32 GetValue() {
      return (UInt32)Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToUInt32_FromSingle : FnFunction<UInt32> {
    [FnArg] protected FnObject<Single> Value;

    public override UInt32 GetValue() {
      return (UInt32)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt32_FromDouble : FnFunction<UInt32> {
    [FnArg] protected FnObject<Double> Value;

    public override UInt32 GetValue() {
      return (UInt32)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt32_FromDecimal : FnFunction<UInt32> {
    [FnArg] protected FnObject<Decimal> Value;

    public override UInt32 GetValue() {
      return (UInt32)Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToUInt32_FromChar : FnFunction<UInt32> {
    [FnArg] protected FnObject<Char> Value;

    public FnFunction_Cast_ToUInt32_FromChar()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override UInt32 GetValue() {
      return (UInt32)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt32_FromString : FnFunction<UInt32> {
    [FnArg] protected FnObject<String> Value;

    public override UInt32 GetValue() {
      String value = Value.GetValue();
      UInt32 output;

      // Cast to UInt32
      if (UInt32.TryParse(value, out output)) {
        return output;
      }

      // Cast floating point String
      return (UInt32)(float.Parse(value));
    }
  }

  internal class FnFunction_Cast_ToUInt32_FromObject : FnFunction<UInt32> {
    [FnArg] protected FnObject<Object> Value;

    public override UInt32 GetValue() {
      return (UInt32)Value.GetValue();
    }
  }
  #endregion
  #region To Int64 Casting Functions
  internal class FnFunction_Cast_ToInt64_FromByte : FnFunction<Int64> {
    [FnArg] protected FnObject<Byte> Value;

    public FnFunction_Cast_ToInt64_FromByte()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Int64 GetValue() {
      return (Int64)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt64_FromSByte : FnFunction<Int64> {
    [FnArg] protected FnObject<SByte> Value;

    public FnFunction_Cast_ToInt64_FromSByte()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Int64 GetValue() {
      return (Int64)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt64_FromInt16 : FnFunction<Int64> {
    [FnArg] protected FnObject<Int16> Value;

    public FnFunction_Cast_ToInt64_FromInt16()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Int64 GetValue() {
      return (Int64)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt64_FromUInt16 : FnFunction<Int64> {
    [FnArg] protected FnObject<UInt16> Value;

    public FnFunction_Cast_ToInt64_FromUInt16()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Int64 GetValue() {
      return (Int64)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt64_FromInt32 : FnFunction<Int64> {
    [FnArg] protected FnObject<Int32> Value;

    public FnFunction_Cast_ToInt64_FromInt32()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Int64 GetValue() {
      return (Int64)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt64_FromUInt32 : FnFunction<Int64> {
    [FnArg] protected FnObject<UInt32> Value;

    public FnFunction_Cast_ToInt64_FromUInt32()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Int64 GetValue() {
      return (Int64)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt64_FromInt64 : FnFunction<Int64> {
    [FnArg] protected FnObject<Int64> Value;

    public override Int64 GetValue() {
      return Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt64_FromUInt64 : FnFunction<Int64> {
    [FnArg] protected FnObject<UInt64> Value;

    public override Int64 GetValue() {
      return (Int64)Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToInt64_FromSingle : FnFunction<Int64> {
    [FnArg] protected FnObject<Single> Value;

    public override Int64 GetValue() {
      return (Int64)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt64_FromDouble : FnFunction<Int64> {
    [FnArg] protected FnObject<Double> Value;

    public override Int64 GetValue() {
      return (Int64)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt64_FromDecimal : FnFunction<Int64> {
    [FnArg] protected FnObject<Decimal> Value;

    public override Int64 GetValue() {
      return (Int64)Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToInt64_FromChar : FnFunction<Int64> {
    [FnArg] protected FnObject<Char> Value;

    public FnFunction_Cast_ToInt64_FromChar()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Int64 GetValue() {
      return (Int64)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToInt64_FromString : FnFunction<Int64> {
    [FnArg] protected FnObject<String> Value;

    public override Int64 GetValue() {
      String value = Value.GetValue();
      Int64 output;

      // Cast to Int64
      if (Int64.TryParse(value, out output)) {
        return output;
      }

      // Cast floating point String
      return (Int64)(float.Parse(value));
    }
  }

  internal class FnFunction_Cast_ToInt64_FromObject : FnFunction<Int64> {
    [FnArg] protected FnObject<Object> Value;

    public override Int64 GetValue() {
      return (Int64)Value.GetValue();
    }
  }
  #endregion
  #region To UInt64 Casting Functions
  internal class FnFunction_Cast_ToUInt64_FromByte : FnFunction<UInt64> {
    [FnArg] protected FnObject<Byte> Value;

    public FnFunction_Cast_ToUInt64_FromByte()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override UInt64 GetValue() {
      return (UInt64)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt64_FromSByte : FnFunction<UInt64> {
    [FnArg] protected FnObject<SByte> Value;

    public override UInt64 GetValue() {
      return (UInt64)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt64_FromInt16 : FnFunction<UInt64> {
    [FnArg] protected FnObject<Int16> Value;

    public override UInt64 GetValue() {
      return (UInt64)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt64_FromUInt16 : FnFunction<UInt64> {
    [FnArg] protected FnObject<UInt16> Value;

    public FnFunction_Cast_ToUInt64_FromUInt16()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override UInt64 GetValue() {
      return (UInt64)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt64_FromInt32 : FnFunction<UInt64> {
    [FnArg] protected FnObject<Int32> Value;

    public override UInt64 GetValue() {
      return (UInt64)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt64_FromUInt32 : FnFunction<UInt64> {
    [FnArg] protected FnObject<UInt32> Value;

    public FnFunction_Cast_ToUInt64_FromUInt32()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override UInt64 GetValue() {
      return (UInt64)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt64_FromInt64 : FnFunction<UInt64> {
    [FnArg] protected FnObject<Int64> Value;

    public override UInt64 GetValue() {
      return (UInt64)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt64_FromUInt64 : FnFunction<UInt64> {
    [FnArg] protected FnObject<UInt64> Value;

    public override UInt64 GetValue() {
      return Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToUInt64_FromSingle : FnFunction<UInt64> {
    [FnArg] protected FnObject<Single> Value;

    public override UInt64 GetValue() {
      return (UInt64)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt64_FromDouble : FnFunction<UInt64> {
    [FnArg] protected FnObject<Double> Value;

    public override UInt64 GetValue() {
      return (UInt64)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt64_FromDecimal : FnFunction<UInt64> {
    [FnArg] protected FnObject<Decimal> Value;

    public override UInt64 GetValue() {
      return (UInt64)Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToUInt64_FromChar : FnFunction<UInt64> {
    [FnArg] protected FnObject<Char> Value;

    public FnFunction_Cast_ToUInt64_FromChar()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override UInt64 GetValue() {
      return (UInt64)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToUInt64_FromString : FnFunction<UInt64> {
    [FnArg] protected FnObject<String> Value;

    public override UInt64 GetValue() {
      String value = Value.GetValue();
      UInt64 output;

      // Cast to UInt64
      if (UInt64.TryParse(value, out output)) {
        return output;
      }

      // Cast floating point String
      return (UInt64)(float.Parse(value));
    }
  }

  internal class FnFunction_Cast_ToUInt64_FromObject : FnFunction<UInt64> {
    [FnArg] protected FnObject<Object> Value;

    public override UInt64 GetValue() {
      return (UInt64)Value.GetValue();
    }
  }
  #endregion

  #region To Single Casting Functions
  internal class FnFunction_Cast_ToSingle_FromByte : FnFunction<Single> {
    [FnArg] protected FnObject<Byte> Value;

    public FnFunction_Cast_ToSingle_FromByte()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Single GetValue() {
      return (Single)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToSingle_FromSByte : FnFunction<Single> {
    [FnArg] protected FnObject<SByte> Value;

    public FnFunction_Cast_ToSingle_FromSByte()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Single GetValue() {
      return (Single)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToSingle_FromInt16 : FnFunction<Single> {
    [FnArg] protected FnObject<Int16> Value;

    public FnFunction_Cast_ToSingle_FromInt16()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Single GetValue() {
      return (Single)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToSingle_FromUInt16 : FnFunction<Single> {
    [FnArg] protected FnObject<UInt16> Value;

    public FnFunction_Cast_ToSingle_FromUInt16()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Single GetValue() {
      return (Single)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToSingle_FromInt32 : FnFunction<Single> {
    [FnArg] protected FnObject<Int32> Value;

    public FnFunction_Cast_ToSingle_FromInt32()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Single GetValue() {
      return (Single)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToSingle_FromUInt32 : FnFunction<Single> {
    [FnArg] protected FnObject<UInt32> Value;

    public FnFunction_Cast_ToSingle_FromUInt32()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Single GetValue() {
      return (Single)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToSingle_FromInt64 : FnFunction<Single> {
    [FnArg] protected FnObject<Int64> Value;

    public FnFunction_Cast_ToSingle_FromInt64()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Single GetValue() {
      return (Single)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToSingle_FromUInt64 : FnFunction<Single> {
    [FnArg] protected FnObject<UInt64> Value;

    public FnFunction_Cast_ToSingle_FromUInt64()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Single GetValue() {
      return (Single)Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToSingle_FromSingle : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Value;

    public override Single GetValue() {
      return Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToSingle_FromDouble : FnFunction<Single> {
    [FnArg] protected FnObject<Double> Value;

    public override Single GetValue() {
      return (Single)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToSingle_FromDecimal : FnFunction<Single> {
    [FnArg] protected FnObject<Decimal> Value;

    public override Single GetValue() {
      return (Single)Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToSingle_FromChar : FnFunction<Single> {
    [FnArg] protected FnObject<Char> Value;

    public FnFunction_Cast_ToSingle_FromChar()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Single GetValue() {
      return (Single)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToSingle_FromString : FnFunction<Single> {
    [FnArg] protected FnObject<String> Value;

    public override Single GetValue() {
      return Single.Parse(Value.GetValue());
    }
  }

  internal class FnFunction_Cast_ToSingle_FromObject : FnFunction<Single> {
    [FnArg] protected FnObject<Object> Value;

    public override Single GetValue() {
      return (Single)Value.GetValue();
    }
  }
  #endregion
  #region To Double Casting Functions
  internal class FnFunction_Cast_ToDouble_FromByte : FnFunction<Double> {
    [FnArg] protected FnObject<Byte> Value;

    public FnFunction_Cast_ToDouble_FromByte()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Double GetValue() {
      return (Double)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToDouble_FromSByte : FnFunction<Double> {
    [FnArg] protected FnObject<SByte> Value;

    public FnFunction_Cast_ToDouble_FromSByte()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Double GetValue() {
      return (Double)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToDouble_FromInt16 : FnFunction<Double> {
    [FnArg] protected FnObject<Int16> Value;

    public FnFunction_Cast_ToDouble_FromInt16()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Double GetValue() {
      return (Double)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToDouble_FromUInt16 : FnFunction<Double> {
    [FnArg] protected FnObject<UInt16> Value;

    public FnFunction_Cast_ToDouble_FromUInt16()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Double GetValue() {
      return (Double)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToDouble_FromInt32 : FnFunction<Double> {
    [FnArg] protected FnObject<Int32> Value;

    public FnFunction_Cast_ToDouble_FromInt32()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Double GetValue() {
      return (Double)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToDouble_FromUInt32 : FnFunction<Double> {
    [FnArg] protected FnObject<UInt32> Value;

    public FnFunction_Cast_ToDouble_FromUInt32()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Double GetValue() {
      return (Double)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToDouble_FromInt64 : FnFunction<Double> {
    [FnArg] protected FnObject<Int64> Value;

    public FnFunction_Cast_ToDouble_FromInt64()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Double GetValue() {
      return (Double)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToDouble_FromUInt64 : FnFunction<Double> {
    [FnArg] protected FnObject<UInt64> Value;

    public FnFunction_Cast_ToDouble_FromUInt64()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Double GetValue() {
      return (Double)Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToDouble_FromSingle : FnFunction<Double> {
    [FnArg] protected FnObject<Single> Value;

    public FnFunction_Cast_ToDouble_FromSingle()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Double GetValue() {
      return (Double)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToDouble_FromDouble : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Value;

    public override Double GetValue() {
      return Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToDouble_FromDecimal : FnFunction<Double> {
    [FnArg] protected FnObject<Decimal> Value;

    public override Double GetValue() {
      return (Double)Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToDouble_FromChar : FnFunction<Double> {
    [FnArg] protected FnObject<Char> Value;

    public FnFunction_Cast_ToDouble_FromChar()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Double GetValue() {
      return (Double)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToDouble_FromString : FnFunction<Double> {
    [FnArg] protected FnObject<String> Value;

    public override Double GetValue() {
      return Double.Parse(Value.GetValue());
    }
  }

  internal class FnFunction_Cast_ToDouble_FromObject : FnFunction<Double> {
    [FnArg] protected FnObject<Object> Value;

    public override Double GetValue() {
      return (Double)Value.GetValue();
    }
  }
  #endregion
  #region To Decimal Casting Functions
  internal class FnFunction_Cast_ToDecimal_FromByte : FnFunction<Decimal> {
    [FnArg] protected FnObject<Byte> Value;

    public FnFunction_Cast_ToDecimal_FromByte()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Decimal GetValue() {
      return (Decimal)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToDecimal_FromSByte : FnFunction<Decimal> {
    [FnArg] protected FnObject<SByte> Value;

    public FnFunction_Cast_ToDecimal_FromSByte()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Decimal GetValue() {
      return (Decimal)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToDecimal_FromInt16 : FnFunction<Decimal> {
    [FnArg] protected FnObject<Int16> Value;

    public FnFunction_Cast_ToDecimal_FromInt16()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Decimal GetValue() {
      return (Decimal)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToDecimal_FromUInt16 : FnFunction<Decimal> {
    [FnArg] protected FnObject<UInt16> Value;

    public FnFunction_Cast_ToDecimal_FromUInt16()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Decimal GetValue() {
      return (Decimal)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToDecimal_FromInt32 : FnFunction<Decimal> {
    [FnArg] protected FnObject<Int32> Value;

    public FnFunction_Cast_ToDecimal_FromInt32()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Decimal GetValue() {
      return (Decimal)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToDecimal_FromUInt32 : FnFunction<Decimal> {
    [FnArg] protected FnObject<UInt32> Value;

    public FnFunction_Cast_ToDecimal_FromUInt32()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Decimal GetValue() {
      return (Decimal)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToDecimal_FromInt64 : FnFunction<Decimal> {
    [FnArg] protected FnObject<Int64> Value;

    public FnFunction_Cast_ToDecimal_FromInt64()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Decimal GetValue() {
      return (Decimal)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToDecimal_FromUInt64 : FnFunction<Decimal> {
    [FnArg] protected FnObject<UInt64> Value;

    public FnFunction_Cast_ToDecimal_FromUInt64()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Decimal GetValue() {
      return (Decimal)Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToDecimal_FromSingle : FnFunction<Decimal> {
    [FnArg] protected FnObject<Single> Value;

    public override Decimal GetValue() {
      return (Decimal)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToDecimal_FromDouble : FnFunction<Decimal> {
    [FnArg] protected FnObject<Double> Value;

    public override Decimal GetValue() {
      return (Decimal)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToDecimal_FromDecimal : FnFunction<Decimal> {
    [FnArg] protected FnObject<Decimal> Value;

    public override Decimal GetValue() {
      return Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToDecimal_FromChar : FnFunction<Decimal> {
    [FnArg] protected FnObject<Char> Value;

    public FnFunction_Cast_ToDecimal_FromChar()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Decimal GetValue() {
      return (Decimal)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToDecimal_FromString : FnFunction<Decimal> {
    [FnArg] protected FnObject<String> Value;

    public override Decimal GetValue() {
      return Decimal.Parse(Value.GetValue());
    }
  }

  internal class FnFunction_Cast_ToDecimal_FromObject : FnFunction<Decimal> {
    [FnArg] protected FnObject<Object> Value;

    public override Decimal GetValue() {
      return (Decimal)Value.GetValue();
    }
  }
  #endregion
  #region To Char Casting Functions
  internal class FnFunction_Cast_ToChar_FromByte : FnFunction<Char> {
    [FnArg] protected FnObject<Byte> Value;

    public override Char GetValue() {
      return (Char)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToChar_FromSByte : FnFunction<Char> {
    [FnArg] protected FnObject<SByte> Value;

    public override Char GetValue() {
      return (Char)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToChar_FromInt16 : FnFunction<Char> {
    [FnArg] protected FnObject<Int16> Value;

    public override Char GetValue() {
      return (Char)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToChar_FromUInt16 : FnFunction<Char> {
    [FnArg] protected FnObject<UInt16> Value;

    public override Char GetValue() {
      return (Char)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToChar_FromInt32 : FnFunction<Char> {
    [FnArg] protected FnObject<Int32> Value;

    public override Char GetValue() {
      return (Char)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToChar_FromUInt32 : FnFunction<Char> {
    [FnArg] protected FnObject<UInt32> Value;

    public override Char GetValue() {
      return (Char)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToChar_FromInt64 : FnFunction<Char> {
    [FnArg] protected FnObject<Int64> Value;

    public override Char GetValue() {
      return (Char)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToChar_FromUInt64 : FnFunction<Char> {
    [FnArg] protected FnObject<UInt64> Value;

    public override Char GetValue() {
      return (Char)Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToChar_FromSingle : FnFunction<Char> {
    [FnArg] protected FnObject<Single> Value;

    public override Char GetValue() {
      return (Char)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToChar_FromDouble : FnFunction<Char> {
    [FnArg] protected FnObject<Double> Value;

    public override Char GetValue() {
      return (Char)Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToChar_FromDecimal : FnFunction<Char> {
    [FnArg] protected FnObject<Decimal> Value;

    public override Char GetValue() {
      return (Char)Value.GetValue();
    }
  }

  internal class FnFunction_Cast_ToChar_FromChar : FnFunction<Char> {
    [FnArg] protected FnObject<Char> Value;

    public override Char GetValue() {
      return Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToChar_FromString : FnFunction<Char> {
    [FnArg] protected FnObject<String> Value;

    public override Char GetValue() {
      String value = Value.GetValue();
      Char result;

      // Try casting to Char
      if (Char.TryParse(value, out result)) {
        return result;
      }

      // Invalid String
      throw new ArgumentException("Conversion failed, casting to Char from this String is not possible", value);
    }
  }

  internal class FnFunction_Cast_ToChar_FromObject : FnFunction<Char> {
    [FnArg] protected FnObject<Object> Value;

    public override Char GetValue() {
      return (Char)Value.GetValue();
    }
  }
  #endregion

  #region To Int32? Casting Functions
  internal class FnFunction_ToNullableInt32_FromNull : FnFunction<Int32?> {
    [FnArg] protected FnObject<Object> Value;

    public FnFunction_ToNullableInt32_FromNull()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Int32? GetValue() {
      return (Int32?)(Value.GetValue());
    }
  }
  #endregion

  #region To String Casting Functions
  internal class FnFunction_Cast_ToString_FromString : FnFunction<String> {
    [FnArg] protected FnObject<String> Value;

    public override String GetValue() {
      return Value.GetValue();
    }
  }
  internal class FnFunction_Cast_ToString_FromObject : FnFunction<String> {
    [FnArg] protected FnObject<Object> Value;

    public override String GetValue() {
      return (String)Value.GetValue();
    }
  }
  #endregion

  #region ToString Functions
  internal class FnFunction_ToString<T> : FnFunction<String> {
    [FnArg] protected FnObject<T> Value;

    public override String GetValue() {
      return Value.GetValue().ToString();
    }
  }
  #endregion

  #region To Object Casting Functions
  internal class FnFunction_Cast_ToObject_FromObject : FnFunction<Object> {
    [FnArg] protected FnObject<Object> Value;

    public FnFunction_Cast_ToObject_FromObject()
        : base(new CompileFlags[] { CompileFlags.IMPLICIT_CONVERSION }) {
    }

    public override Object GetValue() {
      return Value.GetValueAsObject();
    }
  }
  #endregion
  #endregion
  #region Comparison Functions TODO: Add XNOR
  #region IsGreaterThan Functions
  internal class FnFunction_IsGreaterThan_Byte : FnFunction<Boolean> {
    [FnArg] protected FnObject<Byte> LeftVal;
    [FnArg] protected FnObject<Byte> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() > RightVal.GetValue();
    }
  }
  internal class FnFunction_IsGreaterThan_SByte : FnFunction<Boolean> {
    [FnArg] protected FnObject<SByte> LeftVal;
    [FnArg] protected FnObject<SByte> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() > RightVal.GetValue();
    }
  }
  internal class FnFunction_IsGreaterThan_Int16 : FnFunction<Boolean> {
    [FnArg] protected FnObject<Int16> LeftVal;
    [FnArg] protected FnObject<Int16> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() > RightVal.GetValue();
    }
  }
  internal class FnFunction_IsGreaterThan_UInt16 : FnFunction<Boolean> {
    [FnArg] protected FnObject<UInt16> LeftVal;
    [FnArg] protected FnObject<UInt16> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() > RightVal.GetValue();
    }
  }
  internal class FnFunction_IsGreaterThan_Int32 : FnFunction<Boolean> {
    [FnArg] protected FnObject<Int32> LeftVal;
    [FnArg] protected FnObject<Int32> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() > RightVal.GetValue();
    }
  }
  internal class FnFunction_IsGreaterThan_UInt32 : FnFunction<Boolean> {
    [FnArg] protected FnObject<UInt32> LeftVal;
    [FnArg] protected FnObject<UInt32> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() > RightVal.GetValue();
    }
  }
  internal class FnFunction_IsGreaterThan_Int64 : FnFunction<Boolean> {
    [FnArg] protected FnObject<Int64> LeftVal;
    [FnArg] protected FnObject<Int64> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() > RightVal.GetValue();
    }
  }
  internal class FnFunction_IsGreaterThan_UInt64 : FnFunction<Boolean> {
    [FnArg] protected FnObject<UInt64> LeftVal;
    [FnArg] protected FnObject<UInt64> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() > RightVal.GetValue();
    }
  }
  internal class FnFunction_IsGreaterThan_Single : FnFunction<Boolean> {
    [FnArg] protected FnObject<Single> LeftVal;
    [FnArg] protected FnObject<Single> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() > RightVal.GetValue();
    }
  }
  internal class FnFunction_IsGreaterThan_Double : FnFunction<Boolean> {
    [FnArg] protected FnObject<Double> LeftVal;
    [FnArg] protected FnObject<Double> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() > RightVal.GetValue();
    }
  }
  internal class FnFunction_IsGreaterThan_Decimal : FnFunction<Boolean> {
    [FnArg] protected FnObject<Decimal> LeftVal;
    [FnArg] protected FnObject<Decimal> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() > RightVal.GetValue();
    }
  }

  internal class FnFunction_IsGreaterThan_Char : FnFunction<Boolean> {
    [FnArg] protected FnObject<Char> LeftVal;
    [FnArg] protected FnObject<Char> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() > RightVal.GetValue();
    }
  }
  #endregion
  #region IsGreaterThanOrEqual Functions
  internal class FnFunction_IsGreaterThanOrEqual_SByte : FnFunction<Boolean> {
    [FnArg] protected FnObject<SByte> LeftVal;
    [FnArg] protected FnObject<SByte> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() >= RightVal.GetValue();
    }
  }
  internal class FnFunction_IsGreaterThanOrEqual_Byte : FnFunction<Boolean> {
    [FnArg] protected FnObject<Byte> LeftVal;
    [FnArg] protected FnObject<Byte> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() >= RightVal.GetValue();
    }
  }
  internal class FnFunction_IsGreaterThanOrEqual_Int16 : FnFunction<Boolean> {
    [FnArg] protected FnObject<Int16> LeftVal;
    [FnArg] protected FnObject<Int16> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() >= RightVal.GetValue();
    }
  }
  internal class FnFunction_IsGreaterThanOrEqual_UInt16 : FnFunction<Boolean> {
    [FnArg] protected FnObject<UInt16> LeftVal;
    [FnArg] protected FnObject<UInt16> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() >= RightVal.GetValue();
    }
  }
  internal class FnFunction_IsGreaterThanOrEqual_Int32 : FnFunction<Boolean> {
    [FnArg] protected FnObject<Int32> LeftVal;
    [FnArg] protected FnObject<Int32> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() >= RightVal.GetValue();
    }
  }
  internal class FnFunction_IsGreaterThanOrEqual_UInt32 : FnFunction<Boolean> {
    [FnArg] protected FnObject<UInt32> LeftVal;
    [FnArg] protected FnObject<UInt32> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() >= RightVal.GetValue();
    }
  }
  internal class FnFunction_IsGreaterThanOrEqual_Int64 : FnFunction<Boolean> {
    [FnArg] protected FnObject<Int64> LeftVal;
    [FnArg] protected FnObject<Int64> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() >= RightVal.GetValue();
    }
  }
  internal class FnFunction_IsGreaterThanOrEqual_UInt64 : FnFunction<Boolean> {
    [FnArg] protected FnObject<UInt64> LeftVal;
    [FnArg] protected FnObject<UInt64> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() >= RightVal.GetValue();
    }
  }
  internal class FnFunction_IsGreaterThanOrEqual_Single : FnFunction<Boolean> {
    [FnArg] protected FnObject<Single> LeftVal;
    [FnArg] protected FnObject<Single> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() >= RightVal.GetValue();
    }
  }
  internal class FnFunction_IsGreaterThanOrEqual_Double : FnFunction<Boolean> {
    [FnArg] protected FnObject<Double> LeftVal;
    [FnArg] protected FnObject<Double> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() >= RightVal.GetValue();
    }
  }
  internal class FnFunction_IsGreaterThanOrEqual_Decimal : FnFunction<Boolean> {
    [FnArg] protected FnObject<Decimal> LeftVal;
    [FnArg] protected FnObject<Decimal> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() >= RightVal.GetValue();
    }
  }

  internal class FnFunction_IsGreaterThanOrEqual_Char : FnFunction<Boolean> {
    [FnArg] protected FnObject<Char> LeftVal;
    [FnArg] protected FnObject<Char> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() >= RightVal.GetValue();
    }
  }
  #endregion
  #region IsLessThan Functions
  internal class FnFunction_IsLessThan_Byte : FnFunction<Boolean> {
    [FnArg] protected FnObject<Byte> LeftVal;
    [FnArg] protected FnObject<Byte> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() < RightVal.GetValue();
    }
  }
  internal class FnFunction_IsLessThan_SByte : FnFunction<Boolean> {
    [FnArg] protected FnObject<SByte> LeftVal;
    [FnArg] protected FnObject<SByte> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() < RightVal.GetValue();
    }
  }
  internal class FnFunction_IsLessThan_Int16 : FnFunction<Boolean> {
    [FnArg] protected FnObject<Int16> LeftVal;
    [FnArg] protected FnObject<Int16> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() < RightVal.GetValue();
    }
  }
  internal class FnFunction_IsLessThan_UInt16 : FnFunction<Boolean> {
    [FnArg] protected FnObject<UInt16> LeftVal;
    [FnArg] protected FnObject<UInt16> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() < RightVal.GetValue();
    }
  }
  internal class FnFunction_IsLessThan_Int32 : FnFunction<Boolean> {
    [FnArg] protected FnObject<Int32> LeftVal;
    [FnArg] protected FnObject<Int32> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() < RightVal.GetValue();
    }
  }
  internal class FnFunction_IsLessThan_UInt32 : FnFunction<Boolean> {
    [FnArg] protected FnObject<UInt32> LeftVal;
    [FnArg] protected FnObject<UInt32> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() < RightVal.GetValue();
    }
  }
  internal class FnFunction_IsLessThan_Int64 : FnFunction<Boolean> {
    [FnArg] protected FnObject<Int64> LeftVal;
    [FnArg] protected FnObject<Int64> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() < RightVal.GetValue();
    }
  }
  internal class FnFunction_IsLessThan_UInt64 : FnFunction<Boolean> {
    [FnArg] protected FnObject<UInt64> LeftVal;
    [FnArg] protected FnObject<UInt64> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() < RightVal.GetValue();
    }
  }
  internal class FnFunction_IsLessThan_Single : FnFunction<Boolean> {
    [FnArg] protected FnObject<Single> LeftVal;
    [FnArg] protected FnObject<Single> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() < RightVal.GetValue();
    }
  }
  internal class FnFunction_IsLessThan_Double : FnFunction<Boolean> {
    [FnArg] protected FnObject<Double> LeftVal;
    [FnArg] protected FnObject<Double> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() < RightVal.GetValue();
    }
  }
  internal class FnFunction_IsLessThan_Decimal : FnFunction<Boolean> {
    [FnArg] protected FnObject<Decimal> LeftVal;
    [FnArg] protected FnObject<Decimal> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() < RightVal.GetValue();
    }
  }

  internal class FnFunction_IsLessThan_Char : FnFunction<Boolean> {
    [FnArg] protected FnObject<Char> LeftVal;
    [FnArg] protected FnObject<Char> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() < RightVal.GetValue();
    }
  }
  #endregion
  #region IsLessThanOrEqual Functions
  internal class FnFunction_IsLessThanOrEqual_Byte : FnFunction<Boolean> {
    [FnArg] protected FnObject<Byte> LeftVal;
    [FnArg] protected FnObject<Byte> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() <= RightVal.GetValue();
    }
  }
  internal class FnFunction_IsLessThanOrEqual_SByte : FnFunction<Boolean> {
    [FnArg] protected FnObject<SByte> LeftVal;
    [FnArg] protected FnObject<SByte> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() <= RightVal.GetValue();
    }
  }
  internal class FnFunction_IsLessThanOrEqual_Int16 : FnFunction<Boolean> {
    [FnArg] protected FnObject<Int16> LeftVal;
    [FnArg] protected FnObject<Int16> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() <= RightVal.GetValue();
    }
  }
  internal class FnFunction_IsLessThanOrEqual_UInt16 : FnFunction<Boolean> {
    [FnArg] protected FnObject<UInt16> LeftVal;
    [FnArg] protected FnObject<UInt16> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() <= RightVal.GetValue();
    }
  }
  internal class FnFunction_IsLessThanOrEqual_Int32 : FnFunction<Boolean> {
    [FnArg] protected FnObject<Int32> LeftVal;
    [FnArg] protected FnObject<Int32> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() <= RightVal.GetValue();
    }
  }
  internal class FnFunction_IsLessThanOrEqual_UInt32 : FnFunction<Boolean> {
    [FnArg] protected FnObject<UInt32> LeftVal;
    [FnArg] protected FnObject<UInt32> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() <= RightVal.GetValue();
    }
  }
  internal class FnFunction_IsLessThanOrEqual_Int64 : FnFunction<Boolean> {
    [FnArg] protected FnObject<Int64> LeftVal;
    [FnArg] protected FnObject<Int64> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() <= RightVal.GetValue();
    }
  }
  internal class FnFunction_IsLessThanOrEqual_UInt64 : FnFunction<Boolean> {
    [FnArg] protected FnObject<UInt64> LeftVal;
    [FnArg] protected FnObject<UInt64> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() <= RightVal.GetValue();
    }
  }
  internal class FnFunction_IsLessThanOrEqual_Single : FnFunction<Boolean> {
    [FnArg] protected FnObject<Single> LeftVal;
    [FnArg] protected FnObject<Single> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() <= RightVal.GetValue();
    }
  }
  internal class FnFunction_IsLessThanOrEqual_Double : FnFunction<Boolean> {
    [FnArg] protected FnObject<Double> LeftVal;
    [FnArg] protected FnObject<Double> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() <= RightVal.GetValue();
    }
  }
  internal class FnFunction_IsLessThanOrEqual_Decimal : FnFunction<Boolean> {
    [FnArg] protected FnObject<Decimal> LeftVal;
    [FnArg] protected FnObject<Decimal> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() <= RightVal.GetValue();
    }
  }

  internal class FnFunction_IsLessThanOrEqual_Char : FnFunction<Boolean> {
    [FnArg] protected FnObject<Char> LeftVal;
    [FnArg] protected FnObject<Char> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() <= RightVal.GetValue();
    }
  }
  #endregion
  #region IsEqual Functions
  internal class FnFunction_IsEqual_Byte : FnFunction<Boolean> {
    [FnArg] protected FnObject<Byte> LeftVal;
    [FnArg] protected FnObject<Byte> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() == RightVal.GetValue();
    }
  }
  internal class FnFunction_IsEqual_SByte : FnFunction<Boolean> {
    [FnArg] protected FnObject<SByte> LeftVal;
    [FnArg] protected FnObject<SByte> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() == RightVal.GetValue();
    }
  }
  internal class FnFunction_IsEqual_Int16 : FnFunction<Boolean> {
    [FnArg] protected FnObject<Int16> LeftVal;
    [FnArg] protected FnObject<Int16> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() == RightVal.GetValue();
    }
  }
  internal class FnFunction_IsEqual_UInt16 : FnFunction<Boolean> {
    [FnArg] protected FnObject<UInt16> LeftVal;
    [FnArg] protected FnObject<UInt16> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() == RightVal.GetValue();
    }
  }
  internal class FnFunction_IsEqual_Int32 : FnFunction<Boolean> {
    [FnArg] protected FnObject<Int32> LeftVal;
    [FnArg] protected FnObject<Int32> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() == RightVal.GetValue();
    }
  }
  internal class FnFunction_IsEqual_UInt32 : FnFunction<Boolean> {
    [FnArg] protected FnObject<UInt32> LeftVal;
    [FnArg] protected FnObject<UInt32> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() == RightVal.GetValue();
    }
  }
  internal class FnFunction_IsEqual_Int64 : FnFunction<Boolean> {
    [FnArg] protected FnObject<Int64> LeftVal;
    [FnArg] protected FnObject<Int64> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() == RightVal.GetValue();
    }
  }
  internal class FnFunction_IsEqual_UInt64 : FnFunction<Boolean> {
    [FnArg] protected FnObject<UInt64> LeftVal;
    [FnArg] protected FnObject<UInt64> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() == RightVal.GetValue();
    }
  }
  internal class FnFunction_IsEqual_Single : FnFunction<Boolean> {
    [FnArg] protected FnObject<Single> LeftVal;
    [FnArg] protected FnObject<Single> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() == RightVal.GetValue();
    }
  }
  internal class FnFunction_IsEqual_Double : FnFunction<Boolean> {
    [FnArg] protected FnObject<Double> LeftVal;
    [FnArg] protected FnObject<Double> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() == RightVal.GetValue();
    }
  }
  internal class FnFunction_IsEqual_Decimal : FnFunction<Boolean> {
    [FnArg] protected FnObject<Decimal> LeftVal;
    [FnArg] protected FnObject<Decimal> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() == RightVal.GetValue();
    }
  }

  internal class FnFunction_IsEqual_Char : FnFunction<Boolean> {
    [FnArg] protected FnObject<Char> LeftVal;
    [FnArg] protected FnObject<Char> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() == RightVal.GetValue();
    }
  }
  internal class FnFunction_IsEqual_String : FnFunction<Boolean> {
    [FnArg] protected FnObject<String> LeftVal;
    [FnArg] protected FnObject<String> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() == RightVal.GetValue();
    }
  }

  internal class FnFunction_IsEqual_Boolean : FnFunction<Boolean> {
    [FnArg] protected FnObject<Boolean> LeftVal;
    [FnArg] protected FnObject<Boolean> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() == RightVal.GetValue();
    }
  }

  internal class FnFunction_IsEqual_Object : FnFunction<Boolean> {
    [FnArg] protected FnObject<Object> LeftVal;
    [FnArg] protected FnObject<Object> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() == RightVal.GetValue();
    }
  }
  #endregion
  #region IsNotEqual Functions
  internal class FnFunction_IsNotEqual_Byte : FnFunction<Boolean> {
    [FnArg] protected FnObject<Byte> LeftVal;
    [FnArg] protected FnObject<Byte> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() != RightVal.GetValue();
    }
  }
  internal class FnFunction_IsNotEqual_SByte : FnFunction<Boolean> {
    [FnArg] protected FnObject<SByte> LeftVal;
    [FnArg] protected FnObject<SByte> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() != RightVal.GetValue();
    }
  }
  internal class FnFunction_IsNotEqual_Int16 : FnFunction<Boolean> {
    [FnArg] protected FnObject<Int16> LeftVal;
    [FnArg] protected FnObject<Int16> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() != RightVal.GetValue();
    }
  }
  internal class FnFunction_IsNotEqual_UInt16 : FnFunction<Boolean> {
    [FnArg] protected FnObject<UInt16> LeftVal;
    [FnArg] protected FnObject<UInt16> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() != RightVal.GetValue();
    }
  }
  internal class FnFunction_IsNotEqual_Int32 : FnFunction<Boolean> {
    [FnArg] protected FnObject<Int32> LeftVal;
    [FnArg] protected FnObject<Int32> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() != RightVal.GetValue();
    }
  }
  internal class FnFunction_IsNotEqual_UInt32 : FnFunction<Boolean> {
    [FnArg] protected FnObject<UInt32> LeftVal;
    [FnArg] protected FnObject<UInt32> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() != RightVal.GetValue();
    }
  }
  internal class FnFunction_IsNotEqual_Int64 : FnFunction<Boolean> {
    [FnArg] protected FnObject<Int64> LeftVal;
    [FnArg] protected FnObject<Int64> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() != RightVal.GetValue();
    }
  }
  internal class FnFunction_IsNotEqual_UInt64 : FnFunction<Boolean> {
    [FnArg] protected FnObject<UInt64> LeftVal;
    [FnArg] protected FnObject<UInt64> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() != RightVal.GetValue();
    }
  }
  internal class FnFunction_IsNotEqual_Single : FnFunction<Boolean> {
    [FnArg] protected FnObject<Single> LeftVal;
    [FnArg] protected FnObject<Single> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() != RightVal.GetValue();
    }
  }
  internal class FnFunction_IsNotEqual_Double : FnFunction<Boolean> {
    [FnArg] protected FnObject<Double> LeftVal;
    [FnArg] protected FnObject<Double> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() != RightVal.GetValue();
    }
  }
  internal class FnFunction_IsNotEqual_Decimal : FnFunction<Boolean> {
    [FnArg] protected FnObject<Decimal> LeftVal;
    [FnArg] protected FnObject<Decimal> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() != RightVal.GetValue();
    }
  }

  internal class FnFunction_IsNotEqual_Char : FnFunction<Boolean> {
    [FnArg] protected FnObject<Char> LeftVal;
    [FnArg] protected FnObject<Char> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() != RightVal.GetValue();
    }
  }
  internal class FnFunction_IsNotEqual_String : FnFunction<Boolean> {
    [FnArg] protected FnObject<String> LeftVal;
    [FnArg] protected FnObject<String> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() != RightVal.GetValue();
    }
  }

  internal class FnFunction_IsNotEqual_Boolean : FnFunction<Boolean> {
    [FnArg] protected FnObject<Boolean> LeftVal;
    [FnArg] protected FnObject<Boolean> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() != RightVal.GetValue();
    }
  }

  internal class FnFunction_IsNotEqual_Object : FnFunction<Boolean> {
    [FnArg] protected FnObject<Object> LeftVal;
    [FnArg] protected FnObject<Object> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() != RightVal.GetValue();
    }
  }
  #endregion
  #region And Functions
  internal class FnFunction_And : FnFunction<Boolean> {
    [FnArg] protected FnObject<Boolean> LeftVal;
    [FnArg] protected FnObject<Boolean> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() && RightVal.GetValue();
    }
  }
  #endregion
  #region Nand Functions
  internal class FnFunction_Nand : FnFunction<Boolean> {
    [FnArg] protected FnObject<Boolean> LeftVal;
    [FnArg] protected FnObject<Boolean> RightVal;

    public override Boolean GetValue() {
      return !(LeftVal.GetValue() && RightVal.GetValue());
    }
  }
  #endregion
  #region Or Functions
  internal class FnFunction_Or : FnFunction<Boolean> {
    [FnArg] protected FnObject<Boolean> LeftVal;
    [FnArg] protected FnObject<Boolean> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() || RightVal.GetValue();
    }
  }
  #endregion
  #region Nor Functions
  internal class FnFunction_Nor : FnFunction<Boolean> {
    [FnArg] protected FnObject<Boolean> LeftVal;
    [FnArg] protected FnObject<Boolean> RightVal;

    public override Boolean GetValue() {
      return !(LeftVal.GetValue() || RightVal.GetValue());
    }
  }
  #endregion
  #region Xor Functions
  internal class FnFunction_Xor : FnFunction<Boolean> {
    [FnArg] protected FnObject<Boolean> LeftVal;
    [FnArg] protected FnObject<Boolean> RightVal;

    public override Boolean GetValue() {
      return LeftVal.GetValue() ^ RightVal.GetValue();
    }
  }
  #endregion
  //This is where my XNor would go, IF I HAD ONE!! (obscure Fairly Odd Parents reference) Insert when 2.5 conversion is done
  #endregion
  #region Void Function Wrappers
  // Public so people can reference it with their own types
  public class FnFunction_Return<T> : FnFunction<T> {
    [FnArg] protected FnObject<T> ReturnValue;
    [FnArg] protected FnObject<Object> VoidFunction;

    public override T GetValue() {
      // Execute the VoidFunction
      VoidFunction.GetValue();

      // Return the desired value
      return ReturnValue.GetValue();
    }
  }
  #endregion
  #region Nullable Types Helper Functions
  #region IsNull Functions
  internal class FnFunction_IsNull : FnFunction<Boolean> {
    [FnArg] protected FnObject<Object> Param0;

    public override Boolean GetValue() {
      return Param0.GetValue() == null;
    }
  }
  #endregion
  #region Nullable GetValue Functions
  // Allows you to get a value from a nullable type
  // Public so people can extend it with their own types
  public class FnFunction_GetValue<T> : FnFunction<T>
      where T : struct {
    //Function parameters
    [FnArg] protected FnObject<Nullable<T>> NullableObject;

    public override T GetValue() {
      return NullableObject.GetValue().Value;
    }
  }
  #endregion
  #endregion

  #region .Net Math Wrapper Functions
  #region Math.Abs
  internal class FnFunction_Abs_Decimal : FnFunction<Decimal> {
    [FnArg] protected FnObject<Decimal> Param0;

    public override Decimal GetValue() {
      return Math.Abs(Param0.GetValue());
    }
  }
  internal class FnFunction_Abs_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Param0;

    public override Double GetValue() {
      return Math.Abs(Param0.GetValue());
    }
  }
  internal class FnFunction_Abs_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Param0;

    public override Single GetValue() {
      return Math.Abs(Param0.GetValue());
    }
  }

  internal class FnFunction_Abs_Int64 : FnFunction<Int64> {
    [FnArg] protected FnObject<Int64> Param0;

    public override Int64 GetValue() {
      return Math.Abs(Param0.GetValue());
    }
  }
  internal class FnFunction_Abs_Int32 : FnFunction<Int32> {
    [FnArg] protected FnObject<Int32> Param0;

    public override Int32 GetValue() {
      return Math.Abs(Param0.GetValue());
    }
  }
  internal class FnFunction_Abs_Int16 : FnFunction<Int16> {
    [FnArg] protected FnObject<Int16> Param0;

    public override Int16 GetValue() {
      return Math.Abs(Param0.GetValue());
    }
  }
  internal class FnFunction_Abs_SByte : FnFunction<SByte> {
    [FnArg] protected FnObject<SByte> Param0;

    public override SByte GetValue() {
      return Math.Abs(Param0.GetValue());
    }
  }
  #endregion
  #region Math.Acos
  internal class FnFunction_Acos_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Param0;

    public override Double GetValue() {
      return Math.Acos(Param0.GetValue());
    }
  }
  internal class FnFunction_Acos_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Param0;

    public override Single GetValue() {
      return (Single)Math.Acos(Param0.GetValue());
    }
  }
  #endregion
  #region Math.Asin
  internal class FnFunction_Asin_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Param0;

    public override Double GetValue() {
      return Math.Asin(Param0.GetValue());
    }
  }
  internal class FnFunction_Asin_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Param0;

    public override Single GetValue() {
      return (Single)Math.Asin(Param0.GetValue());
    }
  }
  #endregion
  #region Math.Atan
  internal class FnFunction_Atan_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Param0;

    public override Double GetValue() {
      return Math.Atan(Param0.GetValue());
    }
  }
  internal class FnFunction_Atan_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Param0;

    public override Single GetValue() {
      return (Single)Math.Atan(Param0.GetValue());
    }
  }
  #endregion
  #region Math.Atan2
  internal class FnFunction_Atan2_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Param0;
    [FnArg] protected FnObject<Double> Param1;

    public override Double GetValue() {
      return Math.Atan2(Param0.GetValue(), Param1.GetValue());
    }
  }
  internal class FnFunction_Atan2_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Param0;
    [FnArg] protected FnObject<Single> Param1;

    public override Single GetValue() {
      return (Single)Math.Atan2(Param0.GetValue(), Param1.GetValue());
    }
  }
  #endregion
  #region Math.Ceiling
  internal class FnFunction_Ceiling_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Param0;

    public override Double GetValue() {
      return Math.Ceiling(Param0.GetValue());
    }
  }
  internal class FnFunction_Ceiling_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Param0;

    public override Single GetValue() {
      return (Single)Math.Ceiling(Param0.GetValue());
    }
  }
  #endregion
  #region Math.Cos
  internal class FnFunction_Cos_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Param0;

    public override Double GetValue() {
      return Math.Cos(Param0.GetValue());
    }
  }
  internal class FnFunction_Cos_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Param0;

    public override Single GetValue() {
      return (Single)Math.Cos(Param0.GetValue());
    }
  }
  #endregion
  #region Math.Cosh
  internal class FnFunction_Cosh_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Param0;

    public override Double GetValue() {
      return Math.Cosh(Param0.GetValue());
    }
  }
  internal class FnFunction_Cosh_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Param0;

    public override Single GetValue() {
      return (Single)Math.Cosh(Param0.GetValue());
    }
  }
  #endregion
  #region Math.Exp
  internal class FnFunction_Exp_Int32 : FnFunction<Int32> {
    [FnArg] protected FnObject<Int32> Param0;

    public override Int32 GetValue() {
      return (Int32)Math.Exp(Param0.GetValue());
    }
  }
  internal class FnFunction_Exp_UInt32 : FnFunction<UInt32> {
    [FnArg] protected FnObject<UInt32> Param0;

    public override UInt32 GetValue() {
      return (UInt32)Math.Exp(Param0.GetValue());
    }
  }
  internal class FnFunction_Exp_Int64 : FnFunction<Int64> {
    [FnArg] protected FnObject<Int64> Param0;

    public override Int64 GetValue() {
      return (Int64)Math.Exp(Param0.GetValue());
    }
  }
  internal class FnFunction_Exp_UInt64 : FnFunction<UInt64> {
    [FnArg] protected FnObject<UInt64> Param0;

    public override UInt64 GetValue() {
      return (UInt64)Math.Exp(Param0.GetValue());
    }
  }
  internal class FnFunction_Exp_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Param0;

    public override Single GetValue() {
      return (Single)Math.Exp(Param0.GetValue());
    }
  }
  internal class FnFunction_Exp_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Param0;

    public override Double GetValue() {
      return Math.Exp(Param0.GetValue());
    }
  }
  #endregion
  #region Math.Floor
  internal class FnFunction_Floor_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Param0;

    public override Double GetValue() {
      return Math.Floor(Param0.GetValue());
    }
  }
  internal class FnFunction_Floor_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Param0;

    public override Single GetValue() {
      return (Single)Math.Floor(Param0.GetValue());
    }
  }
  #endregion
  #region Math.IEEERemainder
  internal class FnFunction_IEEERemainder : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Param0;
    [FnArg] protected FnObject<Double> Param1;

    public override Double GetValue() {
      return Math.IEEERemainder(Param0.GetValue(), Param1.GetValue());
    }
  }
  #endregion
  #region Math.Log
  internal class FnFunction_Log_BaseE_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Param0;

    public override Single GetValue() {
      return (Single)Math.Log(Param0.GetValue());
    }
  }
  internal class FnFunction_Log_BaseE_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Param0;

    public override Double GetValue() {
      return Math.Log(Param0.GetValue());
    }
  }
  internal class FnFunction_Log_CustomBase_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Param0;
    [FnArg] protected FnObject<Single> Base;

    public override Single GetValue() {
      return (Single)Math.Log(Param0.GetValue(), Base.GetValue());
    }
  }
  internal class FnFunction_Log_CustomBase_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Param0;
    [FnArg] protected FnObject<Double> Base;

    public override Double GetValue() {
      return Math.Log(Param0.GetValue(), Base.GetValue());
    }
  }
  #endregion
  #region Math.Log10
  internal class FnFunction_Log10_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Param0;

    public override Single GetValue() {
      return (Single)Math.Log10(Param0.GetValue());
    }
  }
  internal class FnFunction_Log10_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Param0;

    public override Double GetValue() {
      return Math.Log10(Param0.GetValue());
    }
  }
  #endregion
  #region Math.Max
  internal class FnFunction_Max_Byte : FnFunction<Byte> {
    [FnArg] protected FnObject<Byte> A;
    [FnArg] protected FnObject<Byte> B;

    public override Byte GetValue() {
      return Math.Max(A.GetValue(), B.GetValue());
    }
  }
  internal class FnFunction_Max_SByte : FnFunction<SByte> {
    [FnArg] protected FnObject<SByte> A;
    [FnArg] protected FnObject<SByte> B;

    public override SByte GetValue() {
      return Math.Max(A.GetValue(), B.GetValue());
    }
  }
  internal class FnFunction_Max_Int16 : FnFunction<Int16> {
    [FnArg] protected FnObject<Int16> A;
    [FnArg] protected FnObject<Int16> B;

    public override Int16 GetValue() {
      return Math.Max(A.GetValue(), B.GetValue());
    }
  }
  internal class FnFunction_Max_UInt16 : FnFunction<UInt16> {
    [FnArg] protected FnObject<UInt16> A;
    [FnArg] protected FnObject<UInt16> B;

    public override UInt16 GetValue() {
      return Math.Max(A.GetValue(), B.GetValue());
    }
  }
  internal class FnFunction_Max_Int32 : FnFunction<Int32> {
    [FnArg] protected FnObject<Int32> A;
    [FnArg] protected FnObject<Int32> B;

    public override Int32 GetValue() {
      return Math.Max(A.GetValue(), B.GetValue());
    }
  }
  internal class FnFunction_Max_UInt32 : FnFunction<UInt32> {
    [FnArg] protected FnObject<UInt32> A;
    [FnArg] protected FnObject<UInt32> B;

    public override UInt32 GetValue() {
      return Math.Max(A.GetValue(), B.GetValue());
    }
  }
  internal class FnFunction_Max_Int64 : FnFunction<Int64> {
    [FnArg] protected FnObject<Int64> A;
    [FnArg] protected FnObject<Int64> B;

    public override Int64 GetValue() {
      return Math.Max(A.GetValue(), B.GetValue());
    }
  }
  internal class FnFunction_Max_UInt64 : FnFunction<UInt64> {
    [FnArg] protected FnObject<UInt64> A;
    [FnArg] protected FnObject<UInt64> B;

    public override UInt64 GetValue() {
      return Math.Max(A.GetValue(), B.GetValue());
    }
  }

  internal class FnFunction_Max_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> A;
    [FnArg] protected FnObject<Single> B;

    public override Single GetValue() {
      return Math.Max(A.GetValue(), B.GetValue());
    }
  }
  internal class FnFunction_Max_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> A;
    [FnArg] protected FnObject<Double> B;

    public override Double GetValue() {
      return Math.Max(A.GetValue(), B.GetValue());
    }
  }
  internal class FnFunction_Max_Decimal : FnFunction<Decimal> {
    [FnArg] protected FnObject<Decimal> A;
    [FnArg] protected FnObject<Decimal> B;

    public override Decimal GetValue() {
      return Math.Max(A.GetValue(), B.GetValue());
    }
  }
  #endregion
  #region Math.Min
  internal class FnFunction_Min_Byte : FnFunction<Byte> {
    [FnArg] protected FnObject<Byte> Param0;
    [FnArg] protected FnObject<Byte> Param1;

    public override Byte GetValue() {
      return Math.Min(Param0.GetValue(), Param1.GetValue());
    }
  }
  internal class FnFunction_Min_SByte : FnFunction<SByte> {
    [FnArg] protected FnObject<SByte> Param0;
    [FnArg] protected FnObject<SByte> Param1;

    public override SByte GetValue() {
      return Math.Min(Param0.GetValue(), Param1.GetValue());
    }
  }
  internal class FnFunction_Min_Int16 : FnFunction<Int16> {
    [FnArg] protected FnObject<Int16> Param0;
    [FnArg] protected FnObject<Int16> Param1;

    public override Int16 GetValue() {
      return Math.Min(Param0.GetValue(), Param1.GetValue());
    }
  }
  internal class FnFunction_Min_UInt16 : FnFunction<UInt16> {
    [FnArg] protected FnObject<UInt16> Param0;
    [FnArg] protected FnObject<UInt16> Param1;

    public override UInt16 GetValue() {
      return Math.Min(Param0.GetValue(), Param1.GetValue());
    }
  }
  internal class FnFunction_Min_Int32 : FnFunction<Int32> {
    [FnArg] protected FnObject<Int32> Param0;
    [FnArg] protected FnObject<Int32> Param1;

    public override Int32 GetValue() {
      return Math.Min(Param0.GetValue(), Param1.GetValue());
    }
  }
  internal class FnFunction_Min_UInt32 : FnFunction<UInt32> {
    [FnArg] protected FnObject<UInt32> Param0;
    [FnArg] protected FnObject<UInt32> Param1;

    public override UInt32 GetValue() {
      return Math.Min(Param0.GetValue(), Param1.GetValue());
    }
  }
  internal class FnFunction_Min_Int64 : FnFunction<Int64> {
    [FnArg] protected FnObject<Int64> Param0;
    [FnArg] protected FnObject<Int64> Param1;

    public override Int64 GetValue() {
      return Math.Min(Param0.GetValue(), Param1.GetValue());
    }
  }
  internal class FnFunction_Min_UInt64 : FnFunction<UInt64> {
    [FnArg] protected FnObject<UInt64> Param0;
    [FnArg] protected FnObject<UInt64> Param1;

    public override UInt64 GetValue() {
      return Math.Min(Param0.GetValue(), Param1.GetValue());
    }
  }

  internal class FnFunction_Min_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Param0;
    [FnArg] protected FnObject<Single> Param1;

    public override Single GetValue() {
      return Math.Min(Param0.GetValue(), Param1.GetValue());
    }
  }
  internal class FnFunction_Min_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Param0;
    [FnArg] protected FnObject<Double> Param1;

    public override Double GetValue() {
      return Math.Min(Param0.GetValue(), Param1.GetValue());
    }
  }
  internal class FnFunction_Min_Decimal : FnFunction<Decimal> {
    [FnArg] protected FnObject<Decimal> Param0;
    [FnArg] protected FnObject<Decimal> Param1;

    public override Decimal GetValue() {
      return Math.Min(Param0.GetValue(), Param1.GetValue());
    }
  }
  #endregion
  #region Math.Pow
  internal class FnFunction_Pow_Int32 : FnFunction<Int32> {
    [FnArg] protected FnObject<Int32> Num;
    [FnArg] protected FnObject<Int32> Pow;

    public override Int32 GetValue() {
      return (Int32)Math.Pow(Num.GetValue(), Pow.GetValue());
    }
  }
  internal class FnFunction_Pow_UInt32 : FnFunction<UInt32> {
    [FnArg] protected FnObject<UInt32> Num;
    [FnArg] protected FnObject<UInt32> Pow;

    public override UInt32 GetValue() {
      return (UInt32)Math.Pow(Num.GetValue(), Pow.GetValue());
    }
  }
  internal class FnFunction_Pow_Int64 : FnFunction<Int64> {
    [FnArg] protected FnObject<Int64> Num;
    [FnArg] protected FnObject<Int64> Pow;

    public override Int64 GetValue() {
      return (Int64)Math.Pow(Num.GetValue(), Pow.GetValue());
    }
  }
  internal class FnFunction_Pow_UInt64 : FnFunction<UInt64> {
    [FnArg] protected FnObject<UInt64> Num;
    [FnArg] protected FnObject<UInt64> Pow;

    public override UInt64 GetValue() {
      return (UInt64)Math.Pow(Num.GetValue(), Pow.GetValue());
    }
  }
  internal class FnFunction_Pow_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Num;
    [FnArg] protected FnObject<Single> Pow;

    public override Single GetValue() {
      return (Single)Math.Pow(Num.GetValue(), Pow.GetValue());
    }
  }
  internal class FnFunction_Pow_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Num;
    [FnArg] protected FnObject<Double> Pow;

    public override Double GetValue() {
      return Math.Pow(Num.GetValue(), Pow.GetValue());
    }
  }
  #endregion
  #region Math.Round
  internal class FnFunction_Round_Single_1 : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Num;

    public override Single GetValue() {
      return (Single)Math.Round(Num.GetValue());
    }
  }
  internal class FnFunction_Round_Double_1 : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Num;

    public override Double GetValue() {
      return Math.Round(Num.GetValue());
    }
  }
  internal class FnFunction_Round_Decimal_1 : FnFunction<Decimal> {
    [FnArg] protected FnObject<Decimal> Num;

    public override Decimal GetValue() {
      return Math.Round(Num.GetValue());
    }
  }

  internal class FnFunction_Round_Single_2 : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Num;
    [FnArg] protected FnObject<Int32> Digits;

    public override Single GetValue() {
      return (Single)Math.Round(Num.GetValue(), Digits.GetValue());
    }
  }
  internal class FnFunction_Round_Double_2 : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Num;
    [FnArg] protected FnObject<Int32> Digits;

    public override Double GetValue() {
      return Math.Round(Num.GetValue(), Digits.GetValue());
    }
  }
  internal class FnFunction_Round_Decimal_2 : FnFunction<Decimal> {
    [FnArg] protected FnObject<Decimal> Num;
    [FnArg] protected FnObject<Int32> Digits;

    public override Decimal GetValue() {
      return Math.Round(Num.GetValue(), Digits.GetValue());
    }
  }
  #endregion
  #region Math.Sign
  internal class FnFunction_Sign_SByte : FnFunction<Int32> {
    [FnArg] protected FnObject<SByte> Value;

    public override Int32 GetValue() {
      return Math.Sign(Value.GetValue());
    }
  }
  internal class FnFunction_Sign_Int16 : FnFunction<Int32> {
    [FnArg] protected FnObject<Int16> Value;

    public override Int32 GetValue() {
      return Math.Sign(Value.GetValue());
    }
  }
  internal class FnFunction_Sign_Int32 : FnFunction<Int32> {
    [FnArg] protected FnObject<Int32> Value;

    public override Int32 GetValue() {
      return Math.Sign(Value.GetValue());
    }
  }
  internal class FnFunction_Sign_Int64 : FnFunction<Int32> {
    [FnArg] protected FnObject<Int64> Value;

    public override Int32 GetValue() {
      return Math.Sign(Value.GetValue());
    }
  }
  internal class FnFunction_Sign_Single : FnFunction<Int32> {
    [FnArg] protected FnObject<Single> Value;

    public override Int32 GetValue() {
      return Math.Sign(Value.GetValue());
    }
  }
  internal class FnFunction_Sign_Double : FnFunction<Int32> {
    [FnArg] protected FnObject<Double> Value;

    public override Int32 GetValue() {
      return Math.Sign(Value.GetValue());
    }
  }
  internal class FnFunction_Sign_Decimal : FnFunction<Int32> {
    [FnArg] protected FnObject<Decimal> Value;

    public override Int32 GetValue() {
      return Math.Sign(Value.GetValue());
    }
  }
  #endregion
  #region Math.Sin
  internal class FnFunction_Sin_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Value;

    public override Single GetValue() {
      return (Single)Math.Sin(Value.GetValue());
    }
  }
  internal class FnFunction_Sin_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Value;

    public override Double GetValue() {
      return Math.Sin(Value.GetValue());
    }
  }
  #endregion
  #region Math.Sinh
  internal class FnFunction_Sinh_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Value;

    public override Single GetValue() {
      return (Single)Math.Sinh(Value.GetValue());
    }
  }
  internal class FnFunction_Sinh_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Value;

    public override Double GetValue() {
      return Math.Sinh(Value.GetValue());
    }
  }
  #endregion
  #region Math.Sqrt
  internal class FnFunction_Sqrt_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Num;

    public override Single GetValue() {
      return (Single)Math.Sqrt(Num.GetValue());
    }
  }
  internal class FnFunction_Sqrt_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Num;

    public override Double GetValue() {
      return Math.Sqrt(Num.GetValue());
    }
  }
  #endregion
  #region Math.Tan
  internal class FnFunction_Tan_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Num;

    public override Single GetValue() {
      return (Single)Math.Tan(Num.GetValue());
    }
  }
  internal class FnFunction_Tan_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Num;

    public override Double GetValue() {
      return Math.Tan(Num.GetValue());
    }
  }
  #endregion
  #region Math.Tanh
  internal class FnFunction_Tanh_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Num;

    public override Single GetValue() {
      return (Single)Math.Tanh(Num.GetValue());
    }
  }
  internal class FnFunction_Tanh_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> Num;

    public override Double GetValue() {
      return Math.Tanh(Num.GetValue());
    }
  }
  #endregion
  #endregion

  #region Bezier Curve Functions
  #region Quadratic Bezier Curves
  internal class FnFunction_Bezier_Quadratic_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> P0;
    [FnArg] protected FnObject<Single> P1;
    [FnArg] protected FnObject<Single> P2;

    [FnArg] protected FnObject<Single> S;

    public override Single GetValue() {
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
  internal class FnFunction_Bezier_Quadratic_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> P0;
    [FnArg] protected FnObject<Double> P1;
    [FnArg] protected FnObject<Double> P2;

    [FnArg] protected FnObject<Double> S;

    public override Double GetValue() {
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
  internal class FnFunction_Bezier_Cubic_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> P0;
    [FnArg] protected FnObject<Single> P1;
    [FnArg] protected FnObject<Single> P2;
    [FnArg] protected FnObject<Single> P3;

    [FnArg] protected FnObject<Single> S;

    public override Single GetValue() {
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
  internal class FnFunction_Bezier_Cubic_Double : FnFunction<Double> {
    [FnArg] protected FnObject<Double> P0;
    [FnArg] protected FnObject<Double> P1;
    [FnArg] protected FnObject<Double> P2;
    [FnArg] protected FnObject<Double> P3;

    [FnArg] protected FnObject<Double> S;

    public override Double GetValue() {
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

  #region Other Math Functions
  #region Cycle
  internal class FnFunction_Cycle_Int32 : FnFunction<Int32> {
    [FnArg] protected FnObject<Int32> Num;

    [FnArg] protected FnObject<Int32> LowerBound;
    [FnArg] protected FnObject<Int32> UpperBound;

    public override Int32 GetValue() {
      Int32 value = Num.GetValue();

      Int32 lowerBound = LowerBound.GetValue();
      Int32 upperBound = UpperBound.GetValue();

      return (value - lowerBound) % (upperBound - lowerBound) + lowerBound;
    }
  }
  internal class FnFunction_Cycle_Single : FnFunction<Single> {
    [FnArg] protected FnObject<Single> Num;

    [FnArg] protected FnObject<Single> LowerBound;
    [FnArg] protected FnObject<Single> UpperBound;

    public override Single GetValue() {
      Single value = Num.GetValue();

      Single lowerBound = LowerBound.GetValue();
      Single upperBound = UpperBound.GetValue();

      return (value - lowerBound) % (upperBound - lowerBound) + lowerBound;
    }
  }
  #endregion
  #region RandomInt
  internal class FnFunction_RandomInt : FnFunction<Int32> {
    //The random number generator
    private Random RandomGenerator;

    public FnFunction_RandomInt()
        : base(new CompileFlags[] { CompileFlags.DO_NOT_CACHE }) {
      RandomGenerator = new Random();
    }

    public override Int32 GetValue() {
      // Generate random int
      return RandomGenerator.Next();
    }
  }
  internal class FnFunction_RandomInt_Max : FnFunction<Int32> {
    [FnArg] protected FnObject<Int32> MaxValue;

    // The random number generator
    private Random RandomGenerator;

    public FnFunction_RandomInt_Max()
        : base(new CompileFlags[] { CompileFlags.DO_NOT_CACHE }) {
      RandomGenerator = new Random();
    }

    public override Int32 GetValue() {
      return RandomGenerator.Next(MaxValue.GetValue());
    }
  }
  internal class FnFunction_RandomInt_Min_Max : FnFunction<Int32> {
    [FnArg] protected FnObject<Int32> MinValue;
    [FnArg] protected FnObject<Int32> MaxValue;

    //The random number generator
    private Random RandomGenerator;

    public FnFunction_RandomInt_Min_Max()
        : base(new CompileFlags[] { CompileFlags.DO_NOT_CACHE }) {
      RandomGenerator = new Random();
    }

    public override Int32 GetValue() {
      return RandomGenerator.Next(MinValue.GetValue(), MaxValue.GetValue());
    }
  }
  #endregion
  #endregion

  #region FnObject Parameter Functions
  #region SetParameter
  internal class FnFunction_SetParameter<T> : FnFunction<Object> {
    [FnArg] protected FnVariable<T> Parameter;
    [FnArg] protected FnObject<T> Value;

    public FnFunction_SetParameter()
        : base(new CompileFlags[] { CompileFlags.DO_NOT_CACHE }) {
    }

    public override Object GetValue() {
      //If it's not pre-execute, apply the value to the parameter

      //PROBLEM: If "Paramter" is not an FnVariable this right now provides a very nondescript
      //exception, it will simply say there's a null reference error and point somewhere in the engine
      //Fix this with some specific error catching.
      if (!IsImmutableExecute.Value) {
        Parameter.Value = Value.GetValue();
      }

      return null;
    }
  }
  #endregion
  #endregion

  #region String Functions
  #region String Class Wrapper Functions
  #region SubString
  internal class FnFunction_SubString_StartOnly : FnFunction<String> {
    [FnArg] protected FnObject<String> SourceString;
    [FnArg] protected FnObject<Int32> StartIndex;

    public override String GetValue() {
      return SourceString.GetValue().Substring(StartIndex.GetValue());
    }
  }
  internal class FnFunction_SubString_StartAndEnd : FnFunction<String> {
    [FnArg] protected FnObject<String> SourceString;
    [FnArg] protected FnObject<Int32> StartIndex;
    [FnArg] protected FnObject<Int32> Length;

    public override String GetValue() {
      return SourceString.GetValue().Substring(StartIndex.GetValue(), Length.GetValue());
    }
  }
  #endregion
  #endregion
  #region Custom String Functions
  #region RandomString
  internal class FnFunction_RandomString_WithoutPrefix : FnFunction<String> {
    /// <summary>
    /// Generates the random String.
    /// </summary>
    Random RandomGenerator;

    [FnArg] protected FnObject<Int32> Length;

    public FnFunction_RandomString_WithoutPrefix()
        : base(new CompileFlags[] { CompileFlags.DO_NOT_CACHE }) {
      RandomGenerator = new Random();
    }

    public override String GetValue() {
      //Convert arguments into parameters
      Int32 stringLength = Length.GetValue();

      //Our return value
      StringBuilder output = new StringBuilder("", stringLength);

      //If stringLength <= 0 then we will be returning the empty string
      for (int i = 0; i < stringLength; i++) {
        //the space character is at position 32 <- why did I do this?
        output.Append((Char)(RandomGenerator.Next(33, 126)));
      }

      return output.ToString();
    }
  }
  internal class FnFunction_RandomString_WithPrefix : FnFunction<String> {
    Random RandomGenerator;

    [FnArg] protected FnObject<Int32> Length;
    [FnArg] protected FnObject<String> Prefix;

    public FnFunction_RandomString_WithPrefix()
        : base(new CompileFlags[] { CompileFlags.DO_NOT_CACHE }) {
      RandomGenerator = new Random();
    }

    public override String GetValue() {
      //Convert arguments into parameters
      Int32 stringLength = Length.GetValue();
      String prefix = Prefix.GetValue();
      StringBuilder output = new StringBuilder(prefix, stringLength);

      //If stringLength <= 0 then we will be returning the empty string
      for (int i = prefix.Length; i < stringLength; i++) {
        //the space character is at position 32 <- why did I do this?
        output.Append((Char)(RandomGenerator.Next(33, 126)));
      }

      return output.ToString();
    }
  }
  #endregion
  #region LengthOf
  internal class FnFunction_LengthOf : FnFunction<Int32> {
    [FnArg] protected FnObject<String> Input;

    public override Int32 GetValue() {
      return Input.GetValue().Length;
    }
  }
  #endregion
  #region CharAt
  internal class FnFunction_CharAt : FnFunction<Char> {
    [FnArg] protected FnObject<String> Input;
    [FnArg] protected FnObject<Int32> Index;

    public override Char GetValue() {
      String input = Input.GetValue();
      Int32 index = Index.GetValue();

      if (index >= 0 && index < input.Length) {
        return input[index];
      } else {
        throw new ArgumentException("The index specified is out of range of the string", "String: \"" + input + "\", Index: " + index.ToString());
      }
    }
  }
  #endregion
  #region Reverse
  internal class FnFunction_Reverse : FnFunction<String> {
    [FnArg] protected FnObject<String> Input;

    public override String GetValue() {
      String input = Input.GetValue();
      StringBuilder output = new StringBuilder(input.Length);

      for (int i = 0; i < input.Length; i++) {
        output.Append(input[input.Length - 1 - i]);
      }

      return output.ToString();
    }
  }
  #endregion
  #endregion
  #endregion

  #pragma warning restore 0649
}