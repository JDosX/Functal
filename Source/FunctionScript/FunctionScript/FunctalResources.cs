using System;
using System.Collections.Generic;
using System.Linq;

namespace Functal {
  /// <summary>
  /// Maintains the Functal runtime. Is used to define globally accessible constants,
  /// parameters and functions.
  /// </summary>
  public static class FunctalResources {
    /// <summary>
    /// A random number generator of no seed to use in <see cref="FnFunction{T}"/>s.
    /// </summary>
    public static readonly Random GenericRandom;

    /// <summary>
    /// Stores all the functions that can be used within Functal.
    /// </summary>
    internal static Dictionary<String, FnFunctionGroup> FnFunctions;

    /// <summary>
    /// Stores all the functions that can be used to conduct implicit conversions.
    /// </summary>
    internal static Dictionary<Type, FnFunctionGroup> ImplicitConversionSwitches;

    /// <summary>
    /// Stores the precedence of data types that can be provided as function arguments.
    /// </summary>
    internal static Dictionary<Type, Byte> TypePrecedence;

    /// <summary>
    /// Global parameters that can be accessed by any FnObject
    /// </summary>
    internal static Dictionary<String, FnObject> GlobalParameters;

    /// <summary>
    /// Stores all the constants that can be used within FnScript, along with their name
    /// </summary>
    private static Dictionary<String, FnObject> Constants;

    #region Exception Messages
    /// <summary>
    /// An exception message to use for an invalid number of arguments provided.
    /// </summary>
    private const String InvalidNumberOfArguments =
      "No overload for this function matches the arguments provided.";
    #endregion

    /// <summary>
    /// Constructor.
    /// </summary>
    static FunctalResources() {
      GlobalParameters = new Dictionary<String, FnObject>();
      ImplicitConversionSwitches = new Dictionary<Type, FnFunctionGroup>();

      TypePrecedence = new Dictionary<Type, Byte>() {
        { typeof(SByte), 0 },
        { typeof(Byte), 1 },
        { typeof(Int16), 2 },
        { typeof(UInt16), 3 },
        { typeof(Int32), 4 },
        { typeof(UInt32), 5 },
        { typeof(Int64), 6 },
        { typeof(UInt64), 7 },
        { typeof(Single), 8 },
        { typeof(Double), 10 },
        { typeof(Decimal), 12 },
        // EVERY OTHER DATA TYPE HAS PRECEDENCE 13.
        { typeof(Object), 14 }

        //What about nullable data types? Fix this
        // TODO: Fix type precedence for Nullable Types (is this a language feature? Implicit casting of Nullable types?)
      };

      GenericRandom = new Random();

      InitializeConstants();
      InitializeFunctions();

      InitializeGlobalParameters();
    }

    /// <summary>
    /// Initializes the constants dictionary and adds all the default constants.
    /// </summary>
    private static void InitializeConstants() {
      Constants = new Dictionary<String, FnObject>();

      #region Mathematical Constants
      AddConstant<Single>("Pi", (Single)Math.PI);
      AddConstant<Double>("Pi_Double", Math.PI);
      AddConstant<Single>("E", (Single)Math.E);
      AddConstant<Double>("E_Double", Math.E);
      AddConstant<Double>("Phi", 1.6180339887);
      AddConstant<Int32>("C", 299792458);
      AddConstant<Boolean>("true", true);
      AddConstant<Boolean>("false", false);

      AddConstant<String>("EmptyString", String.Empty);
      AddConstant<Object>("null", null);
      #endregion
    }

    /// <summary>
    /// Initializes default global parameters. Any default global parameters should be placed here.
    /// </summary>
    private static void InitializeGlobalParameters() {}

    /// <summary>
    /// Initializes the functions dictionary and adds in all the defualt functions that can be called.
    /// </summary>
    private static void InitializeFunctions() {
      FnFunctions = new Dictionary<String, FnFunctionGroup>();

      #region Default FnScript API Functions

      #region Addition Functions
      CreateFunctionGroup("Add");
      AddFunctionToGroup("Add", new FnFunction_Add_Int32());
      AddFunctionToGroup("Add", new FnFunction_Add_UInt32());
      AddFunctionToGroup("Add", new FnFunction_Add_Int64());
      AddFunctionToGroup("Add", new FnFunction_Add_UInt64());
      AddFunctionToGroup("Add", new FnFunction_Add_Single());
      AddFunctionToGroup("Add", new FnFunction_Add_Double());
      AddFunctionToGroup("Add", new FnFunction_Add_Decimal());
      AddFunctionToGroup("Add", new FnFunction_Add_String());
      #endregion
      #region Subtraction Functions
      CreateFunctionGroup("Subtract");
      AddFunctionToGroup("Subtract", new FnFunction_Subtract_Int32());
      AddFunctionToGroup("Subtract", new FnFunction_Subtract_UInt32());
      AddFunctionToGroup("Subtract", new FnFunction_Subtract_Int64());
      AddFunctionToGroup("Subtract", new FnFunction_Subtract_UInt64());
      AddFunctionToGroup("Subtract", new FnFunction_Subtract_Single());
      AddFunctionToGroup("Subtract", new FnFunction_Subtract_Double());
      AddFunctionToGroup("Subtract", new FnFunction_Subtract_Decimal());
      #endregion
      #region Multiplication Functions
      CreateFunctionGroup("Multiply");
      AddFunctionToGroup("Multiply", new FnFunction_Multiply_Int32());
      AddFunctionToGroup("Multiply", new FnFunction_Multiply_UInt32());
      AddFunctionToGroup("Multiply", new FnFunction_Multiply_Int64());
      AddFunctionToGroup("Multiply", new FnFunction_Multiply_UInt64());
      AddFunctionToGroup("Multiply", new FnFunction_Multiply_Single());
      AddFunctionToGroup("Multiply", new FnFunction_Multiply_Double());
      AddFunctionToGroup("Multiply", new FnFunction_Multiply_Decimal());
      #endregion
      #region Division Functions
      CreateFunctionGroup("Divide");
      AddFunctionToGroup("Divide", new FnFunction_Divide_Int32());
      AddFunctionToGroup("Divide", new FnFunction_Divide_UInt32());
      AddFunctionToGroup("Divide", new FnFunction_Divide_Int64());
      AddFunctionToGroup("Divide", new FnFunction_Divide_UInt64());
      AddFunctionToGroup("Divide", new FnFunction_Divide_Single());
      AddFunctionToGroup("Divide", new FnFunction_Divide_Double());
      AddFunctionToGroup("Divide", new FnFunction_Divide_Decimal());
      #endregion
      #region Mod Functions
      CreateFunctionGroup("Mod");
      AddFunctionToGroup("Mod", new FnFunction_Mod_Int32());
      AddFunctionToGroup("Mod", new FnFunction_Mod_UInt32());
      AddFunctionToGroup("Mod", new FnFunction_Mod_Int64());
      AddFunctionToGroup("Mod", new FnFunction_Mod_UInt64());
      AddFunctionToGroup("Mod", new FnFunction_Mod_Single());
      AddFunctionToGroup("Mod", new FnFunction_Mod_Double());
      AddFunctionToGroup("Mod", new FnFunction_Mod_Decimal());
      #endregion

      #region Unary Operator Functions
      #region Positive Functions
      CreateFunctionGroup("Positive");
      AddFunctionToGroup("Positive", new FnFunction_Positive_Byte());
      AddFunctionToGroup("Positive", new FnFunction_Positive_SByte());
      AddFunctionToGroup("Positive", new FnFunction_Positive_Int16());
      AddFunctionToGroup("Positive", new FnFunction_Positive_UInt16());
      AddFunctionToGroup("Positive", new FnFunction_Positive_Int32());
      AddFunctionToGroup("Positive", new FnFunction_Positive_UInt32());
      AddFunctionToGroup("Positive", new FnFunction_Positive_Int64());
      AddFunctionToGroup("Positive", new FnFunction_Positive_UInt64());
      AddFunctionToGroup("Positive", new FnFunction_Positive_Single());
      AddFunctionToGroup("Positive", new FnFunction_Positive_Double());
      AddFunctionToGroup("Positive", new FnFunction_Positive_Decimal());
      #endregion
      #region Negative Functions
      CreateFunctionGroup("Negative");
      AddFunctionToGroup("Negative", new FnFunction_Negative_SByte());
      AddFunctionToGroup("Negative", new FnFunction_Negative_Int16());
      AddFunctionToGroup("Negative", new FnFunction_Negative_Int32());
      AddFunctionToGroup("Negative", new FnFunction_Negative_Int64());
      AddFunctionToGroup("Negative", new FnFunction_Negative_Single());
      AddFunctionToGroup("Negative", new FnFunction_Negative_Double());
      AddFunctionToGroup("Negative", new FnFunction_Negative_Decimal());

      AddFunctionToGroup("Negative", new FnFunction_Negative_Byte());
      AddFunctionToGroup("Negative", new FnFunction_Negative_UInt16());
      AddFunctionToGroup("Negative", new FnFunction_Negative_UInt32());
      #endregion
      #region Not Functions
      CreateFunctionGroup("Not");
      AddFunctionToGroup("Not", new FnFunction_Not_Boolean());
      #endregion
      #endregion

      #region Casting Functions
      #region Byte Casting Functions
      CreateFunctionGroup("Byte");
      AddAliasForFunctionGroup("Byte", "byte");
      AddFunctionToGroup("Byte", new FnFunction_Cast_ToByte_FromByte());
      AddFunctionToGroup("Byte", new FnFunction_Cast_ToByte_FromSByte());
      AddFunctionToGroup("Byte", new FnFunction_Cast_ToByte_FromInt16());
      AddFunctionToGroup("Byte", new FnFunction_Cast_ToByte_FromUInt16());
      AddFunctionToGroup("Byte", new FnFunction_Cast_ToByte_FromInt32());
      AddFunctionToGroup("Byte", new FnFunction_Cast_ToByte_FromUInt32());
      AddFunctionToGroup("Byte", new FnFunction_Cast_ToByte_FromInt64());
      AddFunctionToGroup("Byte", new FnFunction_Cast_ToByte_FromUInt64());

      AddFunctionToGroup("Byte", new FnFunction_Cast_ToByte_FromSingle());
      AddFunctionToGroup("Byte", new FnFunction_Cast_ToByte_FromDouble());
      AddFunctionToGroup("Byte", new FnFunction_Cast_ToByte_FromDecimal());

      AddFunctionToGroup("Byte", new FnFunction_Cast_ToByte_FromChar());
      AddFunctionToGroup("Byte", new FnFunction_Cast_ToByte_FromString());

      AddFunctionToGroup("Byte", new FnFunction_Cast_ToByte_FromObject());
      #endregion
      #region SByte Casting Functions
      CreateFunctionGroup("SByte");
      AddAliasForFunctionGroup("SByte", "sbyte");
      AddFunctionToGroup("SByte", new FnFunction_Cast_ToSByte_FromByte());
      AddFunctionToGroup("SByte", new FnFunction_Cast_ToSByte_FromSByte());
      AddFunctionToGroup("SByte", new FnFunction_Cast_ToSByte_FromInt16());
      AddFunctionToGroup("SByte", new FnFunction_Cast_ToSByte_FromUInt16());
      AddFunctionToGroup("SByte", new FnFunction_Cast_ToSByte_FromInt32());
      AddFunctionToGroup("SByte", new FnFunction_Cast_ToSByte_FromUInt32());
      AddFunctionToGroup("SByte", new FnFunction_Cast_ToSByte_FromInt64());
      AddFunctionToGroup("SByte", new FnFunction_Cast_ToSByte_FromUInt64());

      AddFunctionToGroup("SByte", new FnFunction_Cast_ToSByte_FromSingle());
      AddFunctionToGroup("SByte", new FnFunction_Cast_ToSByte_FromDouble());
      AddFunctionToGroup("SByte", new FnFunction_Cast_ToSByte_FromDecimal());

      AddFunctionToGroup("SByte", new FnFunction_Cast_ToSByte_FromChar());
      AddFunctionToGroup("SByte", new FnFunction_CastSByte_FromString());

      AddFunctionToGroup("SByte", new FnFunction_CastSByte_FromObject());
      #endregion
      #region Int16 Casting Functions
      CreateFunctionGroup("Int16");
      AddAliasForFunctionGroup("Int16", "short");
      AddFunctionToGroup("Int16", new FnFunction_Cast_ToInt16_FromByte());
      AddFunctionToGroup("Int16", new FnFunction_Cast_ToInt16_FromSByte());
      AddFunctionToGroup("Int16", new FnFunction_Cast_ToInt16_FromInt16());
      AddFunctionToGroup("Int16", new FnFunction_Cast_ToInt16_FromUInt16());
      AddFunctionToGroup("Int16", new FnFunction_Cast_ToInt16_FromInt32());
      AddFunctionToGroup("Int16", new FnFunction_Cast_ToInt16_FromUInt32());
      AddFunctionToGroup("Int16", new FnFunction_Cast_ToInt16_FromInt64());
      AddFunctionToGroup("Int16", new FnFunction_Cast_ToInt16_FromUInt64());

      AddFunctionToGroup("Int16", new FnFunction_Cast_ToInt16_FromSingle());
      AddFunctionToGroup("Int16", new FnFunction_Cast_ToInt16_FromDouble());
      AddFunctionToGroup("Int16", new FnFunction_Cast_ToInt16_FromDecimal());

      AddFunctionToGroup("Int16", new FnFunction_Cast_ToInt16_FromChar());
      AddFunctionToGroup("Int16", new FnFunction_Cast_ToInt16_FromString());

      AddFunctionToGroup("Int16", new FnFunction_Cast_ToInt16_FromObject());
      #endregion
      #region UInt16 Casting Functions
      CreateFunctionGroup("UInt16");
      AddAliasForFunctionGroup("UInt16", "ushort");
      AddFunctionToGroup("UInt16", new FnFunction_Cast_ToUInt16_FromByte());
      AddFunctionToGroup("UInt16", new FnFunction_Cast_ToUInt16_FromSByte());
      AddFunctionToGroup("UInt16", new FnFunction_Cast_ToUInt16_FromInt16());
      AddFunctionToGroup("UInt16", new FnFunction_Cast_ToUInt16_FromUInt16());
      AddFunctionToGroup("UInt16", new FnFunction_Cast_ToUInt16_FromInt32());
      AddFunctionToGroup("UInt16", new FnFunction_Cast_ToUInt16_FromUInt32());
      AddFunctionToGroup("UInt16", new FnFunction_Cast_ToUInt16_FromInt64());
      AddFunctionToGroup("UInt16", new FnFunction_Cast_ToUInt16_FromUInt64());

      AddFunctionToGroup("UInt16", new FnFunction_Cast_ToUInt16_FromSingle());
      AddFunctionToGroup("UInt16", new FnFunction_Cast_ToUInt16_FromDouble());
      AddFunctionToGroup("UInt16", new FnFunction_Cast_ToUInt16_FromDecimal());

      AddFunctionToGroup("UInt16", new FnFunction_Cast_ToUInt16_FromChar());
      AddFunctionToGroup("UInt16", new FnFunction_Cast_ToUInt16_FromString());

      AddFunctionToGroup("UInt16", new FnFunction_Cast_ToUInt16_FromObject());
      #endregion
      #region Int32 Casting Functions
      CreateFunctionGroup("Int32");
      AddAliasForFunctionGroup("Int32", "int");
      AddFunctionToGroup("Int32", new FnFunction_Cast_ToInt32_FromByte());
      AddFunctionToGroup("Int32", new FnFunction_Cast_ToInt32_FromSByte());
      AddFunctionToGroup("Int32", new FnFunction_Cast_ToInt32_FromInt16());
      AddFunctionToGroup("Int32", new FnFunction_Cast_ToInt32_FromUInt16());
      AddFunctionToGroup("Int32", new FnFunction_Cast_ToInt32_FromInt32());
      AddFunctionToGroup("Int32", new FnFunction_Cast_ToInt32_FromUInt32());
      AddFunctionToGroup("Int32", new FnFunction_Cast_ToInt32_FromInt64());
      AddFunctionToGroup("Int32", new FnFunction_Cast_ToInt32_FromUInt64());

      AddFunctionToGroup("Int32", new FnFunction_Cast_ToInt32_FromSingle());
      AddFunctionToGroup("Int32", new FnFunction_Cast_ToInt32_FromDouble());
      AddFunctionToGroup("Int32", new FnFunction_Cast_ToInt32_FromDecimal());

      AddFunctionToGroup("Int32", new FnFunction_Cast_ToInt32_FromChar());
      AddFunctionToGroup("Int32", new FnFunction_Cast_ToInt32_FromString());

      AddFunctionToGroup("Int32", new FnFunction_Cast_ToInt32_FromObject());
      #endregion
      #region UInt32 Casting Functions
      CreateFunctionGroup("UInt32");
      AddAliasForFunctionGroup("UInt32", "uint");
      AddFunctionToGroup("UInt32", new FnFunction_Cast_ToUInt32_FromByte());
      AddFunctionToGroup("UInt32", new FnFunction_Cast_ToUInt32_FromSByte());
      AddFunctionToGroup("UInt32", new FnFunction_Cast_ToUInt32_FromInt16());
      AddFunctionToGroup("UInt32", new FnFunction_Cast_ToUInt32_FromUInt16());
      AddFunctionToGroup("UInt32", new FnFunction_Cast_ToUInt32_FromInt32());
      AddFunctionToGroup("UInt32", new FnFunction_Cast_ToUInt32_FromUInt32());
      AddFunctionToGroup("UInt32", new FnFunction_Cast_ToUInt32_FromInt64());
      AddFunctionToGroup("UInt32", new FnFunction_Cast_ToUInt32_FromUInt64());

      AddFunctionToGroup("UInt32", new FnFunction_Cast_ToUInt32_FromSingle());
      AddFunctionToGroup("UInt32", new FnFunction_Cast_ToUInt32_FromDouble());
      AddFunctionToGroup("UInt32", new FnFunction_Cast_ToUInt32_FromDecimal());

      AddFunctionToGroup("UInt32", new FnFunction_Cast_ToUInt32_FromChar());
      AddFunctionToGroup("UInt32", new FnFunction_Cast_ToUInt32_FromString());

      AddFunctionToGroup("UInt32", new FnFunction_Cast_ToUInt32_FromObject());
      #endregion
      #region Int64 Casting Functions
      CreateFunctionGroup("Int64");
      AddAliasForFunctionGroup("Int64", "long");
      AddFunctionToGroup("Int64", new FnFunction_Cast_ToInt64_FromByte());
      AddFunctionToGroup("Int64", new FnFunction_Cast_ToInt64_FromSByte());
      AddFunctionToGroup("Int64", new FnFunction_Cast_ToInt64_FromInt16());
      AddFunctionToGroup("Int64", new FnFunction_Cast_ToInt64_FromUInt16());
      AddFunctionToGroup("Int64", new FnFunction_Cast_ToInt64_FromInt32());
      AddFunctionToGroup("Int64", new FnFunction_Cast_ToInt64_FromUInt32());
      AddFunctionToGroup("Int64", new FnFunction_Cast_ToInt64_FromInt64());
      AddFunctionToGroup("Int64", new FnFunction_Cast_ToInt64_FromUInt64());

      AddFunctionToGroup("Int64", new FnFunction_Cast_ToInt64_FromSingle());
      AddFunctionToGroup("Int64", new FnFunction_Cast_ToInt64_FromDouble());
      AddFunctionToGroup("Int64", new FnFunction_Cast_ToInt64_FromDecimal());

      AddFunctionToGroup("Int64", new FnFunction_Cast_ToInt64_FromChar());
      AddFunctionToGroup("Int64", new FnFunction_Cast_ToInt64_FromString());

      AddFunctionToGroup("Int64", new FnFunction_Cast_ToInt64_FromObject());
      #endregion
      #region UInt64 Casting Functions
      CreateFunctionGroup("UInt64");
      AddAliasForFunctionGroup("UInt64", "ulong");
      AddFunctionToGroup("UInt64", new FnFunction_Cast_ToUInt64_FromByte());
      AddFunctionToGroup("UInt64", new FnFunction_Cast_ToUInt64_FromSByte());
      AddFunctionToGroup("UInt64", new FnFunction_Cast_ToUInt64_FromInt16());
      AddFunctionToGroup("UInt64", new FnFunction_Cast_ToUInt64_FromUInt16());
      AddFunctionToGroup("UInt64", new FnFunction_Cast_ToUInt64_FromInt32());
      AddFunctionToGroup("UInt64", new FnFunction_Cast_ToUInt64_FromUInt32());
      AddFunctionToGroup("UInt64", new FnFunction_Cast_ToUInt64_FromInt64());
      AddFunctionToGroup("UInt64", new FnFunction_Cast_ToUInt64_FromUInt64());

      AddFunctionToGroup("UInt64", new FnFunction_Cast_ToUInt64_FromSingle());
      AddFunctionToGroup("UInt64", new FnFunction_Cast_ToUInt64_FromDouble());
      AddFunctionToGroup("UInt64", new FnFunction_Cast_ToUInt64_FromDecimal());

      AddFunctionToGroup("UInt64", new FnFunction_Cast_ToUInt64_FromChar());
      AddFunctionToGroup("UInt64", new FnFunction_Cast_ToUInt64_FromString());

      AddFunctionToGroup("UInt64", new FnFunction_Cast_ToUInt64_FromObject());
      #endregion
      #region Single Casting Functions
      CreateFunctionGroup("Single");
      AddAliasForFunctionGroup("Single", "float");
      AddFunctionToGroup("Single", new FnFunction_Cast_ToSingle_FromByte());
      AddFunctionToGroup("Single", new FnFunction_Cast_ToSingle_FromSByte());
      AddFunctionToGroup("Single", new FnFunction_Cast_ToSingle_FromInt16());
      AddFunctionToGroup("Single", new FnFunction_Cast_ToSingle_FromUInt16());
      AddFunctionToGroup("Single", new FnFunction_Cast_ToSingle_FromInt32());
      AddFunctionToGroup("Single", new FnFunction_Cast_ToSingle_FromUInt32());
      AddFunctionToGroup("Single", new FnFunction_Cast_ToSingle_FromInt64());
      AddFunctionToGroup("Single", new FnFunction_Cast_ToSingle_FromUInt64());

      AddFunctionToGroup("Single", new FnFunction_Cast_ToSingle_FromSingle());
      AddFunctionToGroup("Single", new FnFunction_Cast_ToSingle_FromDouble());
      AddFunctionToGroup("Single", new FnFunction_Cast_ToSingle_FromDecimal());

      AddFunctionToGroup("Single", new FnFunction_Cast_ToSingle_FromChar());
      AddFunctionToGroup("Single", new FnFunction_Cast_ToSingle_FromString());

      AddFunctionToGroup("Single", new FnFunction_Cast_ToSingle_FromObject());
      #endregion
      #region Double Casting Functions
      CreateFunctionGroup("Double");
      AddAliasForFunctionGroup("Double", "double");
      AddFunctionToGroup("Double", new FnFunction_Cast_ToDouble_FromByte());
      AddFunctionToGroup("Double", new FnFunction_Cast_ToDouble_FromSByte());
      AddFunctionToGroup("Double", new FnFunction_Cast_ToDouble_FromInt16());
      AddFunctionToGroup("Double", new FnFunction_Cast_ToDouble_FromUInt16());
      AddFunctionToGroup("Double", new FnFunction_Cast_ToDouble_FromInt32());
      AddFunctionToGroup("Double", new FnFunction_Cast_ToDouble_FromUInt32());
      AddFunctionToGroup("Double", new FnFunction_Cast_ToDouble_FromInt64());
      AddFunctionToGroup("Double", new FnFunction_Cast_ToDouble_FromUInt64());

      AddFunctionToGroup("Double", new FnFunction_Cast_ToDouble_FromSingle());
      AddFunctionToGroup("Double", new FnFunction_Cast_ToDouble_FromDouble());
      AddFunctionToGroup("Double", new FnFunction_Cast_ToDouble_FromDecimal());

      AddFunctionToGroup("Double", new FnFunction_Cast_ToDouble_FromChar());
      AddFunctionToGroup("Double", new FnFunction_Cast_ToDouble_FromString());

      AddFunctionToGroup("Double", new FnFunction_Cast_ToDouble_FromObject());
      #endregion
      #region Decimal Casting Functions
      CreateFunctionGroup("Decimal");
      AddAliasForFunctionGroup("Decimal", "decimal");
      AddFunctionToGroup("Decimal", new FnFunction_Cast_ToDecimal_FromByte());
      AddFunctionToGroup("Decimal", new FnFunction_Cast_ToDecimal_FromSByte());
      AddFunctionToGroup("Decimal", new FnFunction_Cast_ToDecimal_FromInt16());
      AddFunctionToGroup("Decimal", new FnFunction_Cast_ToDecimal_FromUInt16());
      AddFunctionToGroup("Decimal", new FnFunction_Cast_ToDecimal_FromInt32());
      AddFunctionToGroup("Decimal", new FnFunction_Cast_ToDecimal_FromUInt32());
      AddFunctionToGroup("Decimal", new FnFunction_Cast_ToDecimal_FromInt64());
      AddFunctionToGroup("Decimal", new FnFunction_Cast_ToDecimal_FromUInt64());

      AddFunctionToGroup("Decimal", new FnFunction_Cast_ToDecimal_FromSingle());
      AddFunctionToGroup("Decimal", new FnFunction_Cast_ToDecimal_FromDouble());
      AddFunctionToGroup("Decimal", new FnFunction_Cast_ToDecimal_FromDecimal());

      AddFunctionToGroup("Decimal", new FnFunction_Cast_ToDecimal_FromChar());
      AddFunctionToGroup("Decimal", new FnFunction_Cast_ToDecimal_FromString());

      AddFunctionToGroup("Decimal", new FnFunction_Cast_ToDecimal_FromObject());
      #endregion

      #region Char Casting Functions
      CreateFunctionGroup("Char");
      AddAliasForFunctionGroup("Char", "char");
      AddFunctionToGroup("Char", new FnFunction_Cast_ToChar_FromByte());
      AddFunctionToGroup("Char", new FnFunction_Cast_ToChar_FromSByte());
      AddFunctionToGroup("Char", new FnFunction_Cast_ToChar_FromInt16());
      AddFunctionToGroup("Char", new FnFunction_Cast_ToChar_FromUInt16());
      AddFunctionToGroup("Char", new FnFunction_Cast_ToChar_FromInt32());
      AddFunctionToGroup("Char", new FnFunction_Cast_ToChar_FromUInt32());
      AddFunctionToGroup("Char", new FnFunction_Cast_ToChar_FromInt64());
      AddFunctionToGroup("Char", new FnFunction_Cast_ToChar_FromUInt64());

      AddFunctionToGroup("Char", new FnFunction_Cast_ToChar_FromSingle());
      AddFunctionToGroup("Char", new FnFunction_Cast_ToChar_FromDouble());
      AddFunctionToGroup("Char", new FnFunction_Cast_ToChar_FromDecimal());

      AddFunctionToGroup("Char", new FnFunction_Cast_ToChar_FromChar());
      AddFunctionToGroup("Char", new FnFunction_Cast_ToChar_FromString());

      AddFunctionToGroup("Char", new FnFunction_Cast_ToChar_FromObject());
      #endregion
      #region String Casting Functions
      CreateFunctionGroup("String");
      AddAliasForFunctionGroup("String", "string");
      AddFunctionToGroup("String", new FnFunction_Cast_ToString_FromString());

      AddFunctionToGroup("String", new FnFunction_Cast_ToString_FromObject());
      #endregion
      #region ToString Functions
      CreateFunctionGroup("ToString");
      AddFunctionToGroup("ToString", new FnFunction_ToString<Byte>());
      AddFunctionToGroup("ToString", new FnFunction_ToString<SByte>());
      AddFunctionToGroup("ToString", new FnFunction_ToString<Int16>());
      AddFunctionToGroup("ToString", new FnFunction_ToString<UInt16>());
      AddFunctionToGroup("ToString", new FnFunction_ToString<Int32>());
      AddFunctionToGroup("ToString", new FnFunction_ToString<UInt32>());
      AddFunctionToGroup("ToString", new FnFunction_ToString<Int64>());
      AddFunctionToGroup("ToString", new FnFunction_ToString<UInt64>());

      AddFunctionToGroup("ToString", new FnFunction_ToString<Single>());
      AddFunctionToGroup("ToString", new FnFunction_ToString<Double>());
      AddFunctionToGroup("ToString", new FnFunction_ToString<Decimal>());

      AddFunctionToGroup("ToString", new FnFunction_ToString<Char>());
      AddFunctionToGroup("ToString", new FnFunction_ToString<String>());

      AddFunctionToGroup("ToString", new FnFunction_ToString<Boolean>());

      AddFunctionToGroup("ToString", new FnFunction_ToString<Object>());
      #endregion

      #region Int32? Casting Functions
      CreateFunctionGroup("NullableInt32");
      AddFunctionToGroup("NullableInt32", new FnFunction_ToNullableInt32_FromNull());
      #endregion

      #region Object Casting Functions
      CreateFunctionGroup("Object");
      AddAliasForFunctionGroup("Object", "object");
      AddFunctionToGroup("Object", new FnFunction_Cast_ToObject_FromObject());
      #endregion
      #endregion
      #region Implicit Conversion Functions

      //#region Int32? Implicit Conversion Functions
      // There's an issue with this, but I don't remember what it is... Something about FnScript not being able to determine the correct overload when passing a struct to a Function which accepts Nullable<struct>?
      //AddSwitch("ImplicitToNullableInt32", new List<CompileFlags> { CompileFlags.IMPLICIT_CONVERSION });
      //AddFunctionToGroup<Int32?>("ImplicitToNullableInt32", ImplicitToNullableInt32_FromChar, new List<Type> { typeof(Char) });
      //AddFunctionToGroup<Int32?>("ImplicitToNullableInt32", ImplicitToNullableInt32_FromByte, new List<Type> { typeof(Byte) });
      //AddFunctionToGroup<Int32?>("ImplicitToNullableInt32", ImplicitToNullableInt32_FromSByte, new List<Type> { typeof(SByte) });
      //AddFunctionToGroup<Int32?>("ImplicitToNullableInt32", ImplicitToNullableInt32_FromInt16, new List<Type> { typeof(Int16) });
      //AddFunctionToGroup<Int32?>("ImplicitToNullableInt32", ImplicitToNullableInt32_FromUInt16, new List<Type> { typeof(UInt16) });
      //AddFunctionToGroup<Int32?>("ImplicitToNullableInt32", ImplicitToNullableInt32_FromInt32, new List<Type> { typeof(Int32) });
      //AddFunctionToGroup<Int32?>("ImplicitToNullableInt32", ImplicitToNullableInt32_FromNull, new List<Type> { typeof(Object) });
      //#endregion
      #endregion

      #region Comparison Functions
      #region IsGreaterThan Functions
      CreateFunctionGroup("IsGreaterThan");
      AddFunctionToGroup("IsGreaterThan", new FnFunction_IsGreaterThan_Byte());
      AddFunctionToGroup("IsGreaterThan", new FnFunction_IsGreaterThan_SByte());
      AddFunctionToGroup("IsGreaterThan", new FnFunction_IsGreaterThan_Int16());
      AddFunctionToGroup("IsGreaterThan", new FnFunction_IsGreaterThan_UInt16());
      AddFunctionToGroup("IsGreaterThan", new FnFunction_IsGreaterThan_Int32());
      AddFunctionToGroup("IsGreaterThan", new FnFunction_IsGreaterThan_UInt32());
      AddFunctionToGroup("IsGreaterThan", new FnFunction_IsGreaterThan_Int64());
      AddFunctionToGroup("IsGreaterThan", new FnFunction_IsGreaterThan_UInt64());
      AddFunctionToGroup("IsGreaterThan", new FnFunction_IsGreaterThan_Single());
      AddFunctionToGroup("IsGreaterThan", new FnFunction_IsGreaterThan_Double());
      AddFunctionToGroup("IsGreaterThan", new FnFunction_IsGreaterThan_Decimal());

      AddFunctionToGroup("IsGreaterThan", new FnFunction_IsGreaterThan_Char());
      #endregion
      #region IsGreaterThanOrEqual Functions
      CreateFunctionGroup("IsGreaterThanOrEqual");
      AddFunctionToGroup("IsGreaterThanOrEqual", new FnFunction_IsGreaterThanOrEqual_Byte());
      AddFunctionToGroup("IsGreaterThanOrEqual", new FnFunction_IsGreaterThanOrEqual_SByte());
      AddFunctionToGroup("IsGreaterThanOrEqual", new FnFunction_IsGreaterThanOrEqual_Int16());
      AddFunctionToGroup("IsGreaterThanOrEqual", new FnFunction_IsGreaterThanOrEqual_UInt16());
      AddFunctionToGroup("IsGreaterThanOrEqual", new FnFunction_IsGreaterThanOrEqual_Int32());
      AddFunctionToGroup("IsGreaterThanOrEqual", new FnFunction_IsGreaterThanOrEqual_UInt32());
      AddFunctionToGroup("IsGreaterThanOrEqual", new FnFunction_IsGreaterThanOrEqual_Int64());
      AddFunctionToGroup("IsGreaterThanOrEqual", new FnFunction_IsGreaterThanOrEqual_UInt64());
      AddFunctionToGroup("IsGreaterThanOrEqual", new FnFunction_IsGreaterThanOrEqual_Single());
      AddFunctionToGroup("IsGreaterThanOrEqual", new FnFunction_IsGreaterThanOrEqual_Double());
      AddFunctionToGroup("IsGreaterThanOrEqual", new FnFunction_IsGreaterThanOrEqual_Decimal());

      AddFunctionToGroup("IsGreaterThanOrEqual", new FnFunction_IsGreaterThanOrEqual_Char());
      #endregion
      #region IsLessThan Functions
      CreateFunctionGroup("IsLessThan");
      AddFunctionToGroup("IsLessThan", new FnFunction_IsLessThan_Byte());
      AddFunctionToGroup("IsLessThan", new FnFunction_IsLessThan_SByte());
      AddFunctionToGroup("IsLessThan", new FnFunction_IsLessThan_Int16());
      AddFunctionToGroup("IsLessThan", new FnFunction_IsLessThan_UInt16());
      AddFunctionToGroup("IsLessThan", new FnFunction_IsLessThan_Int32());
      AddFunctionToGroup("IsLessThan", new FnFunction_IsLessThan_UInt32());
      AddFunctionToGroup("IsLessThan", new FnFunction_IsLessThan_Int64());
      AddFunctionToGroup("IsLessThan", new FnFunction_IsLessThan_UInt64());
      AddFunctionToGroup("IsLessThan", new FnFunction_IsLessThan_Single());
      AddFunctionToGroup("IsLessThan", new FnFunction_IsLessThan_Double());
      AddFunctionToGroup("IsLessThan", new FnFunction_IsLessThan_Decimal());

      AddFunctionToGroup("IsLessThan", new FnFunction_IsLessThan_Char());
      #endregion
      #region IsLessThanOrEqual Functions
      CreateFunctionGroup("IsLessThanOrEqual");
      AddFunctionToGroup("IsLessThanOrEqual", new FnFunction_IsLessThanOrEqual_Byte());
      AddFunctionToGroup("IsLessThanOrEqual", new FnFunction_IsLessThanOrEqual_SByte());
      AddFunctionToGroup("IsLessThanOrEqual", new FnFunction_IsLessThanOrEqual_Int16());
      AddFunctionToGroup("IsLessThanOrEqual", new FnFunction_IsLessThanOrEqual_UInt16());
      AddFunctionToGroup("IsLessThanOrEqual", new FnFunction_IsLessThanOrEqual_Int32());
      AddFunctionToGroup("IsLessThanOrEqual", new FnFunction_IsLessThanOrEqual_UInt32());
      AddFunctionToGroup("IsLessThanOrEqual", new FnFunction_IsLessThanOrEqual_Int64());
      AddFunctionToGroup("IsLessThanOrEqual", new FnFunction_IsLessThanOrEqual_UInt64());
      AddFunctionToGroup("IsLessThanOrEqual", new FnFunction_IsLessThanOrEqual_Single());
      AddFunctionToGroup("IsLessThanOrEqual", new FnFunction_IsLessThanOrEqual_Double());
      AddFunctionToGroup("IsLessThanOrEqual", new FnFunction_IsLessThanOrEqual_Decimal());

      AddFunctionToGroup("IsLessThanOrEqual", new FnFunction_IsLessThanOrEqual_Char());
      #endregion
      #region IsEqual Functions
      CreateFunctionGroup("IsEqual");
      AddFunctionToGroup("IsEqual", new FnFunction_IsEqual_Byte());
      AddFunctionToGroup("IsEqual", new FnFunction_IsEqual_SByte());
      AddFunctionToGroup("IsEqual", new FnFunction_IsEqual_Int16());
      AddFunctionToGroup("IsEqual", new FnFunction_IsEqual_UInt16());
      AddFunctionToGroup("IsEqual", new FnFunction_IsEqual_Int32());
      AddFunctionToGroup("IsEqual", new FnFunction_IsEqual_UInt32());
      AddFunctionToGroup("IsEqual", new FnFunction_IsEqual_Int64());
      AddFunctionToGroup("IsEqual", new FnFunction_IsEqual_UInt64());
      AddFunctionToGroup("IsEqual", new FnFunction_IsEqual_Single());
      AddFunctionToGroup("IsEqual", new FnFunction_IsEqual_Double());
      AddFunctionToGroup("IsEqual", new FnFunction_IsEqual_Decimal());

      AddFunctionToGroup("IsEqual", new FnFunction_IsEqual_Char());
      AddFunctionToGroup("IsEqual", new FnFunction_IsEqual_String());

      AddFunctionToGroup("IsEqual", new FnFunction_IsEqual_Boolean());

      AddFunctionToGroup("IsEqual", new FnFunction_IsEqual_Object());
      #endregion
      #region IsNotEqualFunctions
      CreateFunctionGroup("IsNotEqual");
      AddFunctionToGroup("IsNotEqual", new FnFunction_IsNotEqual_Byte());
      AddFunctionToGroup("IsNotEqual", new FnFunction_IsNotEqual_SByte());
      AddFunctionToGroup("IsNotEqual", new FnFunction_IsNotEqual_Int16());
      AddFunctionToGroup("IsNotEqual", new FnFunction_IsNotEqual_UInt16());
      AddFunctionToGroup("IsNotEqual", new FnFunction_IsNotEqual_Int32());
      AddFunctionToGroup("IsNotEqual", new FnFunction_IsNotEqual_UInt32());
      AddFunctionToGroup("IsNotEqual", new FnFunction_IsNotEqual_Int64());
      AddFunctionToGroup("IsNotEqual", new FnFunction_IsNotEqual_UInt64());
      AddFunctionToGroup("IsNotEqual", new FnFunction_IsNotEqual_Single());
      AddFunctionToGroup("IsNotEqual", new FnFunction_IsNotEqual_Double());
      AddFunctionToGroup("IsNotEqual", new FnFunction_IsNotEqual_Decimal());

      AddFunctionToGroup("IsNotEqual", new FnFunction_IsNotEqual_Char());
      AddFunctionToGroup("IsNotEqual", new FnFunction_IsNotEqual_String());

      AddFunctionToGroup("IsNotEqual", new FnFunction_IsNotEqual_Boolean());

      AddFunctionToGroup("IsNotEqual", new FnFunction_IsNotEqual_Object());
      #endregion
      #region And Functions
      CreateFunctionGroup("And");
      AddFunctionToGroup("And", new FnFunction_And());
      #endregion
      #region Nand Functions
      CreateFunctionGroup("Nand");
      AddFunctionToGroup("Nand", new FnFunction_Nand());
      #endregion
      #region Or Functions
      CreateFunctionGroup("Or");
      AddFunctionToGroup("Or", new FnFunction_Or());
      #endregion
      #region Nor Functions
      CreateFunctionGroup("Nor");
      AddFunctionToGroup("Nor", new FnFunction_Nor());
      #endregion
      #region Xor Functions
      CreateFunctionGroup("Xor");
      AddFunctionToGroup("Xor", new FnFunction_Xor());
      #endregion
      #endregion

      #region Void Function Wrappers
      CreateFunctionGroup("Return");

      // Add multiple void functions as arguments overloads (2 void functionss, 3 void functionss, etc...).
      AddFunctionToGroup("Return", new FnFunction_Return<Byte>());
      AddFunctionToGroup("Return", new FnFunction_Return<SByte>());
      AddFunctionToGroup("Return", new FnFunction_Return<Int16>());
      AddFunctionToGroup("Return", new FnFunction_Return<UInt16>());
      AddFunctionToGroup("Return", new FnFunction_Return<Int32>());
      AddFunctionToGroup("Return", new FnFunction_Return<UInt32>());
      AddFunctionToGroup("Return", new FnFunction_Return<Int64>());
      AddFunctionToGroup("Return", new FnFunction_Return<UInt64>());
      AddFunctionToGroup("Return", new FnFunction_Return<Single>());
      AddFunctionToGroup("Return", new FnFunction_Return<Double>());
      AddFunctionToGroup("Return", new FnFunction_Return<Decimal>());

      AddFunctionToGroup("Return", new FnFunction_Return<Char>());
      AddFunctionToGroup("Return", new FnFunction_Return<String>());

      AddFunctionToGroup("Return", new FnFunction_Return<Object>());
      #endregion

      #region Nullable Types Helper Functions
      CreateFunctionGroup("IsNull");
      AddFunctionToGroup("IsNull", new FnFunction_IsNull());

      #region Nullable GetValue Functions
      CreateFunctionGroup("GetValue");
      AddFunctionToGroup("GetValue", new FnFunction_GetValue<Byte>());
      AddFunctionToGroup("GetValue", new FnFunction_GetValue<SByte>());
      AddFunctionToGroup("GetValue", new FnFunction_GetValue<Int16>());
      AddFunctionToGroup("GetValue", new FnFunction_GetValue<UInt16>());
      AddFunctionToGroup("GetValue", new FnFunction_GetValue<Int32>());
      AddFunctionToGroup("GetValue", new FnFunction_GetValue<UInt32>());
      AddFunctionToGroup("GetValue", new FnFunction_GetValue<Int64>());
      AddFunctionToGroup("GetValue", new FnFunction_GetValue<UInt64>());
      AddFunctionToGroup("GetValue", new FnFunction_GetValue<Single>());
      AddFunctionToGroup("GetValue", new FnFunction_GetValue<Double>());
      AddFunctionToGroup("GetValue", new FnFunction_GetValue<Decimal>());
      AddFunctionToGroup("GetValue", new FnFunction_GetValue<Char>());
      #endregion
      #endregion

      #region .Net Math Wrapper Functions
      #region Math.Abs
      CreateFunctionGroup("Abs");
      AddFunctionToGroup("Abs", new FnFunction_Abs_Decimal());
      AddFunctionToGroup("Abs", new FnFunction_Abs_Double());
      AddFunctionToGroup("Abs", new FnFunction_Abs_Single());
      AddFunctionToGroup("Abs", new FnFunction_Abs_Int64());
      AddFunctionToGroup("Abs", new FnFunction_Abs_Int32());
      AddFunctionToGroup("Abs", new FnFunction_Abs_Int16());
      AddFunctionToGroup("Abs", new FnFunction_Abs_SByte());
      #endregion
      #region Math.Acos
      CreateFunctionGroup("Acos");
      AddFunctionToGroup("Acos", new FnFunction_Acos_Double());
      AddFunctionToGroup("Acos", new FnFunction_Acos_Single());
      #endregion
      #region Math.Asin
      CreateFunctionGroup("Asin");
      AddFunctionToGroup("Asin", new FnFunction_Asin_Double());
      AddFunctionToGroup("Asin", new FnFunction_Asin_Single());
      #endregion
      #region Math.Atan
      CreateFunctionGroup("Atan");
      AddFunctionToGroup("Atan", new FnFunction_Atan_Double());
      AddFunctionToGroup("Atan", new FnFunction_Atan_Single());
      #endregion
      #region Math.Atan2
      CreateFunctionGroup("Atan2");
      AddFunctionToGroup("Atan2", new FnFunction_Atan2_Single());
      AddFunctionToGroup("Atan2", new FnFunction_Atan2_Double());
      #endregion
      #region Math.Ceiling
      CreateFunctionGroup("Ceiling");
      AddFunctionToGroup("Ceiling", new FnFunction_Ceiling_Single());
      AddFunctionToGroup("Ceiling", new FnFunction_Ceiling_Double());
      #endregion
      #region Math.Cos
      CreateFunctionGroup("Cos");
      AddFunctionToGroup("Cos", new FnFunction_Cos_Single());
      AddFunctionToGroup("Cos", new FnFunction_Cos_Double());
      #endregion
      #region Math.Cosh
      CreateFunctionGroup("Cosh");
      AddFunctionToGroup("Cosh", new FnFunction_Cosh_Single());
      AddFunctionToGroup("Cosh", new FnFunction_Cosh_Double());
      #endregion
      #region Math.Exp
      CreateFunctionGroup("Exp");
      AddFunctionToGroup("Exp", new FnFunction_Exp_Int32());
      AddFunctionToGroup("Exp", new FnFunction_Exp_UInt32());
      AddFunctionToGroup("Exp", new FnFunction_Exp_Int64());
      AddFunctionToGroup("Exp", new FnFunction_Exp_UInt64());
      AddFunctionToGroup("Exp", new FnFunction_Exp_Single());
      AddFunctionToGroup("Exp", new FnFunction_Exp_Double());
      #endregion
      #region Math.Floor
      CreateFunctionGroup("Floor");
      AddFunctionToGroup("Floor", new FnFunction_Floor_Single());
      AddFunctionToGroup("Floor", new FnFunction_Floor_Double());
      #endregion
      #region Math.IEEERemainder
      CreateFunctionGroup("IEEERemainder");
      AddFunctionToGroup("IEEERemainder", new FnFunction_IEEERemainder());
      #endregion
      #region Math.Log
      CreateFunctionGroup("Log");
      AddFunctionToGroup("Log", new FnFunction_Log_BaseE_Single());
      AddFunctionToGroup("Log", new FnFunction_Log_BaseE_Double());
      AddFunctionToGroup("Log", new FnFunction_Log_CustomBase_Single());
      AddFunctionToGroup("Log", new FnFunction_Log_CustomBase_Double());
      #endregion
      #region Math.Log10
      CreateFunctionGroup("Log10");
      AddFunctionToGroup("Log10", new FnFunction_Log10_Single());
      AddFunctionToGroup("Log10", new FnFunction_Log10_Double());
      #endregion
      #region Math.Max
      CreateFunctionGroup("Max");
      AddFunctionToGroup("Max", new FnFunction_Max_Byte());
      AddFunctionToGroup("Max", new FnFunction_Max_SByte());
      AddFunctionToGroup("Max", new FnFunction_Max_Int16());
      AddFunctionToGroup("Max", new FnFunction_Max_UInt16());
      AddFunctionToGroup("Max", new FnFunction_Max_Int32());
      AddFunctionToGroup("Max", new FnFunction_Max_UInt32());
      AddFunctionToGroup("Max", new FnFunction_Max_Int64());
      AddFunctionToGroup("Max", new FnFunction_Max_UInt64());
      AddFunctionToGroup("Max", new FnFunction_Max_Single());
      AddFunctionToGroup("Max", new FnFunction_Max_Double());
      AddFunctionToGroup("Max", new FnFunction_Max_Decimal());
      #endregion
      #region Math.Min
      CreateFunctionGroup("Min");
      AddFunctionToGroup("Min", new FnFunction_Min_Byte());
      AddFunctionToGroup("Min", new FnFunction_Min_SByte());
      AddFunctionToGroup("Min", new FnFunction_Min_Int16());
      AddFunctionToGroup("Min", new FnFunction_Min_UInt16());
      AddFunctionToGroup("Min", new FnFunction_Min_Int32());
      AddFunctionToGroup("Min", new FnFunction_Min_UInt32());
      AddFunctionToGroup("Min", new FnFunction_Min_Int64());
      AddFunctionToGroup("Min", new FnFunction_Min_UInt64());
      AddFunctionToGroup("Min", new FnFunction_Min_Single());
      AddFunctionToGroup("Min", new FnFunction_Min_Double());
      AddFunctionToGroup("Min", new FnFunction_Min_Decimal());
      #endregion
      #region Math.Pow
      CreateFunctionGroup("Pow");
      AddFunctionToGroup("Pow", new FnFunction_Pow_Int32());
      AddFunctionToGroup("Pow", new FnFunction_Pow_UInt32());
      AddFunctionToGroup("Pow", new FnFunction_Pow_Int64());
      AddFunctionToGroup("Pow", new FnFunction_Pow_UInt64());
      AddFunctionToGroup("Pow", new FnFunction_Pow_Double());
      #endregion
      #region Math.Round
      CreateFunctionGroup("Round");
      AddFunctionToGroup("Round", new FnFunction_Round_Single_1());
      AddFunctionToGroup("Round", new FnFunction_Round_Double_1());
      AddFunctionToGroup("Round", new FnFunction_Round_Decimal_1());

      AddFunctionToGroup("Round", new FnFunction_Round_Single_2());
      AddFunctionToGroup("Round", new FnFunction_Round_Double_2());
      AddFunctionToGroup("Round", new FnFunction_Round_Decimal_2());
      #endregion
      #region Math.Sign
      CreateFunctionGroup("Sign");
      AddFunctionToGroup("Sign", new FnFunction_Sign_Decimal());
      AddFunctionToGroup("Sign", new FnFunction_Sign_Double());
      AddFunctionToGroup("Sign", new FnFunction_Sign_Single());
      AddFunctionToGroup("Sign", new FnFunction_Sign_Int64());
      AddFunctionToGroup("Sign", new FnFunction_Sign_Int32());
      AddFunctionToGroup("Sign", new FnFunction_Sign_Int16());
      AddFunctionToGroup("Sign", new FnFunction_Sign_SByte());
      #endregion
      #region Math.Sin
      CreateFunctionGroup("Sin");
      AddFunctionToGroup("Sin", new FnFunction_Sin_Single());
      AddFunctionToGroup("Sin", new FnFunction_Sin_Double());
      #endregion
      #region Math.Sinh
      CreateFunctionGroup("Sinh");
      AddFunctionToGroup("Sinh", new FnFunction_Sinh_Single());
      AddFunctionToGroup("Sinh", new FnFunction_Sinh_Double());
      #endregion
      #region Math.Sqrt
      CreateFunctionGroup("Sqrt");
      AddFunctionToGroup("Sqrt", new FnFunction_Sqrt_Single());
      AddFunctionToGroup("Sqrt", new FnFunction_Sqrt_Double());
      #endregion
      #region Math.Tan
      CreateFunctionGroup("Tan");
      AddFunctionToGroup("Tan", new FnFunction_Tan_Single());
      AddFunctionToGroup("Tan", new FnFunction_Tan_Double());
      #endregion
      #region Math.Tanh
      CreateFunctionGroup("Tanh");
      AddFunctionToGroup("Tanh", new FnFunction_Tanh_Single());
      AddFunctionToGroup("Tanh", new FnFunction_Tanh_Double());
      #endregion
      #endregion

      #region Bezier Curve Functions
      CreateFunctionGroup("BezierCurve");
      AddFunctionToGroup("BezierCurve", new FnFunction_Bezier_Quadratic_Single());
      AddFunctionToGroup("BezierCurve", new FnFunction_Bezier_Quadratic_Double());
      AddFunctionToGroup("BezierCurve", new FnFunction_Bezier_Cubic_Single());
      AddFunctionToGroup("BezierCurve", new FnFunction_Bezier_Cubic_Double());
      #endregion

      #region Other Maths Functions
      #region Cycle
      CreateFunctionGroup("Cycle");
      AddFunctionToGroup("Cycle", new FnFunction_Cycle_Int32());
      AddFunctionToGroup("Cycle", new FnFunction_Cycle_Single());
      #endregion
      #region RandomInt
      CreateFunctionGroup("RandomInt");
      AddFunctionToGroup("RandomInt", new FnFunction_RandomInt());
      AddFunctionToGroup("RandomInt", new FnFunction_RandomInt_Max());
      AddFunctionToGroup("RandomInt", new FnFunction_RandomInt_Min_Max());
      #endregion
      #endregion

      #region FnObject Parameter Functions
      CreateFunctionGroup("SetParameter");
      AddFunctionToGroup("SetParameter", new FnFunction_SetParameter<Byte>());
      AddFunctionToGroup("SetParameter", new FnFunction_SetParameter<SByte>());
      AddFunctionToGroup("SetParameter", new FnFunction_SetParameter<Int16>());
      AddFunctionToGroup("SetParameter", new FnFunction_SetParameter<UInt16>());
      AddFunctionToGroup("SetParameter", new FnFunction_SetParameter<Int32>());
      AddFunctionToGroup("SetParameter", new FnFunction_SetParameter<UInt32>());
      AddFunctionToGroup("SetParameter", new FnFunction_SetParameter<Int64>());
      AddFunctionToGroup("SetParameter", new FnFunction_SetParameter<UInt64>());
      AddFunctionToGroup("SetParameter", new FnFunction_SetParameter<Single>());
      AddFunctionToGroup("SetParameter", new FnFunction_SetParameter<Double>());
      AddFunctionToGroup("SetParameter", new FnFunction_SetParameter<Decimal>());
      AddFunctionToGroup("SetParameter", new FnFunction_SetParameter<Char>());
      AddFunctionToGroup("SetParameter", new FnFunction_SetParameter<String>());

      // This function won't provide universal Parameter setting available for all data types,
      // but it's required to get setting parameters of data type "object" to work
      AddFunctionToGroup("SetParameter", new FnFunction_SetParameter<Object>());

      AddFunctionToGroup("SetParameter", new FnFunction_SetParameter<Int32?>());
      #endregion

      #region String Functions
      #region String Class Wrapper Functions
      #region SubString
      CreateFunctionGroup("SubString");
      AddFunctionToGroup("SubString", new FnFunction_SubString_StartOnly());
      AddFunctionToGroup("SubString", new FnFunction_SubString_StartAndEnd());
      #endregion
      #endregion
      #region Custom String Functions
      #region RandomString
      CreateFunctionGroup("RandomString");
      AddFunctionToGroup("RandomString", new FnFunction_RandomString_WithoutPrefix());
      AddFunctionToGroup("RandomString", new FnFunction_RandomString_WithPrefix());
      #endregion
      #region LengthOf
      CreateFunctionGroup("LengthOf");
      AddFunctionToGroup("LengthOf", new FnFunction_LengthOf());
      #endregion
      #region CharAt
      CreateFunctionGroup("CharAt");
      AddFunctionToGroup("CharAt", new FnFunction_CharAt());
      #endregion
      #region Reverse
      CreateFunctionGroup("Reverse");
      AddFunctionToGroup("Reverse", new FnFunction_Reverse());
      #endregion
      #endregion
      #endregion

      #endregion
    }

    #region Global Parameter Mutation Functions.

    /// <summary>
    /// Defines a global parameter, initialized with the specified value.
    /// </summary>
    /// <typeparam name="TInput">The data type of the global parameter.</typeparam>
    /// <param name="parameterName">The name of the global parameter.</param>
    /// <param name="parameterValue">The value to initialize the parameter with.</param>
    /// <exception cref="ArgumentException">
    /// Thrown if a global parameter already exists with the name specified in
    /// <paramref name="parameterName"/>.
    /// </exception>
    public static void AddGlobalParameter<TInput>(String parameterName, TInput parameterValue) {
      if (!GlobalParameters.ContainsKey(parameterName)) {
        GlobalParameters.Add(parameterName, new FnVariable<TInput>(parameterValue));
      } else {
        throw new ArgumentException("Parameter name already exists.", parameterName);
      }
    }

    /// <summary>
    /// Sets the value of the global parameter of the specified name with the specified value.
    /// </summary>
    /// <typeparam name="TInput">The data type of the global parameter.</typeparam>
    /// <param name="parameterName">The name of the global parameter.</param>
    /// <param name="parameterValue">The value to assign to the parameter.</param>
    /// <exception cref="ArgumentException">
    /// Thrown if a global parameter of the specified name and type does not exist.
    /// </exception>
    public static void SetGlobalParameter<TInput>(String parameterName, TInput parameterValue) {
      if (GlobalParameters.ContainsKey(parameterName)) {
        if (GlobalParameters[parameterName] is FnVariable<TInput>) {
          (GlobalParameters[parameterName] as FnVariable<TInput>).Value = parameterValue;
        } else {
          throw new ArgumentException(String.Format(
            "Parameter/input type mismatch, expected type {0}, recieved value of type {1}",
            GlobalParameters[parameterName].GetWrappedObjectType(), typeof(TInput))
          );
        }
      } else {
        throw new ArgumentException(
          String.Format("Parameter of name \"{0}\" doesn't exist.", parameterName)
        );
      }
    }

    #endregion

    /// <summary>
    /// Defines a constant with the specified name, type and value.
    /// </summary>
    /// <typeparam name="T">The data type of the constant.</typeparam>
    /// <param name="name">The name of the constant.</param>
    /// <param name="data">The value of the constant.</param>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="name"/> is of an invalid format. Constant names must start with
    /// a letter or underscore, and each following character must be either a letter, number or
    /// undersore.
    /// </exception>
    public static void AddConstant<T>(String name, T data) {
      // Check the validity of the constant name, constants can only be made of letters, digits or
      // underscores, and must start with a letter or an underscore.
      if (IsValidName(name)) {
        Constants.Add(name, new FnConstant<T>(data));
      } else {
        throw new ArgumentException(
          "Invalid constant name provided. Names for constants can only contain underscores, " +
          "letters or digits, must start with an underscore or a letter, and must not be blank"
        );
      }
    }

    /// <summary>
    /// Creates a new function group with the specified name. Once a group is created,
    /// <see cref="FnFunction{Type}"/>s can be added to it to create function overloads.
    /// Functions can then be called from a Functal expression using the name of the group.
    /// </summary>
    /// <param name="name">The name of the group.</param>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="name"/> is of an invalid format. Function group names must start
    /// with a letter or underscore, and each following character must be either a letter, number or
    /// undersore.
    /// </exception>
    public static void CreateFunctionGroup(String name) {
      if (IsValidName(name) && !FnFunctions.ContainsKey(name)) {
        FnFunctions.Add(name, new FnFunctionGroup(name));
      } else {
        throw new ArgumentException(
          "Invalid function group name provided. Names for switches can only contain " +
          "underscores, letters or digits, must start with an underscore or a letter, and must " +
          "not be blank", name
        );
      }
    }

    /// <summary>
    /// Creates an alias for a function group. Function groups can be called within a Functal
    /// expression using any aliased name.
    /// </summary>
    /// <param name="groupName">The name of the function group to alias.</param>
    /// <param name="alias">The alias.</param>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="alias"/> is of an invalid format. Function group names must start
    /// with a letter or underscore, and each following character must be either a letter, number or
    /// undersore.
    /// </exception>
    public static void AddAliasForFunctionGroup(String groupName, String alias) {
      if (IsValidName(alias) && !FnFunctions.ContainsKey(alias)) {
        FnFunctions.Add(alias, FnFunctions[groupName]);
      } else {
        throw new ArgumentException(
          "Invalid alias name provided. Aliases for switches can only contain underscores, " +
          "letters or digits, must start with an underscore or a letter, and must not be blank",
          groupName
        );
      }
    }

    /// <summary>
    /// Adds an <see cref="FnFunction{T}"/> to the function group of the provided name.
    /// </summary>
    /// <typeparam name="T">The return type of the function.</typeparam>
    /// <param name="name">The name of the group to add it to.</param>
    /// <param name="function">An initialized copy of the function.</param>
    /// <exception cref="ArgumentException">
    /// Thrown if a function group with name <paramref name="name"/> does not exist.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the provided function is flagged with
    /// <see cref="FnFunction{T}.CompileFlags.IMPLICIT_CONVERSION"/> but has more than one
    /// parameter. Implicit conversion functions can only take one argument.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the provided function is flagged with
    /// <see cref="FnFunction{T}.CompileFlags.IMPLICIT_CONVERSION"/> but another function already
    /// exists which handles the same implicit conversion.
    /// </exception>
    public static void AddFunctionToGroup<T>(String name, FnFunction<T> function) {
      if (FnFunctions.ContainsKey(name)) {
        FnFunctions[name].AddFunctionPointer(new FnFunctionPointer<T>(function));
        // We do check for an overload conflict, but instead of doing it here it's done in
        // FnFunctionSwitch.AddFunctionPointer().
      } else {
        throw new ArgumentException(
          "Invalid function name provided. A function group by this name does not exist.", name
        );
      }

      // If this function has an implicit conversion flag.
      if (
        function.Flags != null &&
        function.Flags.Contains(FnFunction<T>.CompileFlags.IMPLICIT_CONVERSION)
      ) {
        if (function.ArgumentTypes == null || function.ArgumentTypes.Length != 1) {
          throw new ArgumentException(
            "The provided FnFunction is marked as an implicit conversion function, but has the " +
            "incorrect number of parameters. To be a valid Implicit Converion function it must " +
            "have exactly one parameter."
          );
        }

        // We have now established that the implicit conversion function provided accepts exactly one argument. Now we
        // have to determine if it can be added to the list of implicit conversion groups.

        // If we don't have an implicit conversion switch for this data type yet, create it.
        if (!ImplicitConversionSwitches.ContainsKey(typeof(T))) {
          ImplicitConversionSwitches.Add(typeof(T), new FnFunctionGroup("ImplicitTo_" + typeof(T)));
        }

        // Now we check to see if this implicit conversion has been handled already, by looping through the functions in
        // that group and checking their input parameter type.
        foreach (FnFunctionPointer m in ImplicitConversionSwitches[typeof(T)].FunctionPointers) {
          if (m.GetFunctionTypeArray()[0] == function.ArgumentTypes[0]) {
            throw new ArgumentException(
              "The implicit conversion specified is already handled by another FnFunction", function.ToString()
            );
          }
        }

        // If we are successful, add the FnFunction to the implicit conversion group.
        ImplicitConversionSwitches[typeof(T)].AddFunctionPointer(new FnFunctionPointer<T>(function));
      }
    }

    /// <summary>
    /// Returns the ambiguity score of a provided argument type versus the desired argument type. The higher the
    /// ambiguity score, the more ambiguous the function call is. If a score of -1 is returned, then you cannot implicitly
    /// convert between the two types.
    /// </summary>
    /// <param name="functionType">The parameter type for the function.</param>
    /// <param name="argumentType">The data type of the provided argument.</param>
    /// <returns></returns>
    internal static Int32 GetAmbiguityScore(Type functionType, Type argumentType) {
      // If the function type can be ambiguous.
      if (TypePrecedence.ContainsKey(functionType)) {
        if (TypePrecedence.ContainsKey(argumentType)) {
          if (TypePrecedence[functionType] % 2 == 0) {    // If we have a signed function data type
            if ((TypePrecedence[argumentType] % 2 == 1) && (TypePrecedence[argumentType] > TypePrecedence[functionType])) {     // If we have an unsigned argument data type this is higher precedence than the function type.
              return -1;
            }
          }

          return TypePrecedence[functionType] - TypePrecedence[argumentType];
        } else {
          if (argumentType == typeof(Char)) {  //if it's a char then we have to do some weird stuff
            return TypePrecedence[functionType] - TypePrecedence[typeof(UInt16)];
          } else { //if it's anything else, give it ambiguity level 13 and return the result
            return TypePrecedence[functionType] - 13;      // 13'S A MAGIC NUMBER BUT IT'S THERE BECAUSE THAT'S THE GAP THAT WAS LEFT BETWEEN DECIMAL AND OBJECT FOR AMBIGUITY SCORES
          }
        }
      } else {
        return -1;
      }
    }

    /// <summary>
    /// Determines if the string specified is a valid name for a Function or Constant to be used in Functal.
    /// </summary>
    /// <param name="name">The name to verify</param>
    private static Boolean IsValidName(String name) {
      if (String.IsNullOrEmpty(name)) {
        return false;
      }

      if (!(name[0] == '_'
            || (name[0] >= 'a' && name[0] <= 'z')
            || (name[0] >= 'A' && name[0] <= 'Z'))
         ) {
        return false;
      }

      for (int i = 1; i < name.Length; i++) {
        if (
          !(name[i] == '_'
            || (name[i] >= 'a' && name[i] <= 'z')
            || (name[i] >= 'A' && name[i] <= 'Z')
            || (name[i] >= '0' && name[i] <= '9'))
        ) {
          return false;
        }
      }

      return true;
    }

    /// <summary>
    /// Returns true if a constant with the specified name exists, false otherwise.
    /// </summary>
    /// <param name="name">The name to verify.</param>
    public static Boolean DoesConstantExist(String name) {
      return Constants.ContainsKey(name);
    }

    /// <summary>
    /// Returns true if a function group with the spedified name exists, false otherwise.
    /// </summary>
    /// <param name="name">The name to verify</param>
    /// <returns></returns>
    public static Boolean DoesFunctionGroupExist(String name) {
      return FnFunctions.ContainsKey(name);
    }

    /// <summary>
    /// Returns the <see cref="FnFunctionGroup"/> with the specified name.
    /// </summary>
    /// <param name="name">The name of the function group.</param>
    internal static FnFunctionGroup GetFunctionGroup(String name) {
      if (DoesFunctionGroupExist(name)) { return FnFunctions[name]; }
      throw new ArgumentException(
        String.Format("The function you have requested ({0}) does not exist", name)
      );
    }

    /// <summary>
    /// Returns the <see cref="FnObject"/> containing the constant with the specified name.
    /// </summary>
    /// <param name="name">The name of the constant.</param>
    /// <exception cref="ArgumentException">
    /// Thrown if a constant of name <paramref name="name"/> doesn't exist.
    /// </exception>
    public static FnObject GetConstant(String name) {
      if (DoesConstantExist(name)) { return Constants[name]; }
      throw new ArgumentException(
        String.Format("The constant you have requested ({0}) does not exist", name)
      );
    }

    /// <summary>
    /// Determines if the FnObject provided contains integral data
    /// </summary>
    /// <param name="operand">The FnObject to check</param>
    /// <returns></returns>
    private static Boolean IsIntegerType(FnObject operand) {
      if (operand is FnObject<Char> || operand is FnObject<SByte> || operand is FnObject<Byte>
          || operand is FnObject<Int16> || operand is FnObject<UInt16>
          || operand is FnObject<Int32> || operand is FnObject<UInt32>
          || operand is FnObject<Int64> || operand is FnObject<UInt64>) {
        return true;
      }
      return false;
    }

    /// <summary>
    /// Determines if the Type provided is an integral type.
    /// </summary>
    /// <param name="type">The type to check</param>
    /// <returns></returns>
    private static Boolean IsIntegerType(Type type) {
      if (type == typeof(Char) || type == typeof(SByte) || type == typeof(Byte)
          || type == typeof(Int16) || type == typeof(UInt16)
          || type == typeof(Int32) || type == typeof(UInt32)
          || type == typeof(Int64) || type == typeof(UInt64)) {
        return true;
      }
      return false;
    }

    /// <summary>
    /// Determines if the FnObject provided contains floating point data (Single or Double).
    /// </summary>
    /// <param name="operand">The FnObject to check</param>
    /// <returns></returns>
    private static Boolean IsFloatType(FnObject operand) {
      return (operand is FnObject<Single> || operand is FnObject<Double>);
    }

    /// <summary>
    /// Determines if the Type provided is a floating point data type (Single or Double)
    /// </summary>
    /// <param name="type">The Type to check</param>
    /// <returns></returns>
    private static Boolean IsFloatType(Type type) {
      return (type == typeof(Single) || type == typeof(Double));
    }

    /// <summary>
    /// Determines if the FnObject provided is a valid numerical data type
    /// </summary>
    /// <param name="operand">The FnObject to check</param>
    /// <returns></returns>
    private static Boolean IsNumberType(FnObject operand) {
      return (IsIntegerType(operand) || IsFloatType(operand));
    }

    /// <summary>
    /// Determines if the Type provided is a valid numerical data type
    /// </summary>
    /// <param name="type">The Type to check</param>
    /// <returns></returns>
    private static Boolean IsNumberType(Type type) {
      return (IsIntegerType(type) || IsFloatType(type));
    }
  }
}
