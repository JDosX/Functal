using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionScript {
  /// <summary>
  /// Contains resources for the FunctionScript language, such as available functions, constants and global variables.
  /// </summary>
  public static class FnScriptResources {
    /// <summary>
    /// Stores all the constants that can be used within FnScript, along with their name
    /// </summary>
    private static Dictionary<String, FnObject> Constants;

    /// <summary>
    /// Stores all the functions that can be used within FunctionScript.
    /// </summary>
    internal static Dictionary<String, FnMethodGroup> FnMethods;

    /// <summary>
    /// Stores all the functions that can be used to conduct implicit conversions.
    /// </summary>
    internal static Dictionary<Type, FnMethodGroup> ImplicitConversionSwitches;

    /// <summary>
    /// Stores the precedence of data types that can be provided as arguments to methods.
    /// </summary>
    internal static Dictionary<Type, Byte> TypePrecedence;

    /// <summary>
    /// Global parameters that can be accessed by any FnObject
    /// </summary>
    public static Dictionary<String, FnObject> GlobalParameters;

    #region Exception Messages
    const String InvalidNumberOfArguments = "No overload for this function matches the arguments provided.";
    #endregion

    /// <summary>
    /// A random number generator of no seed to use in FunctionScript methods.
    /// </summary>
    public static readonly Random GenericRandom;

    /// <summary>
    /// Constructor.
    /// </summary>
    static FnScriptResources() {
      GlobalParameters = new Dictionary<String, FnObject>();
      ImplicitConversionSwitches = new Dictionary<Type, FnMethodGroup>();

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
      InitializeMethods();

      InitializeGlobalParameters();
    }

    /// <summary>
    /// Initializes the constants dictionary and adds in all the default constants that can be used from the FnScript API
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
    /// Initializes the methods dictionary and adds in all the defualt methods that can be called from the FnScript API
    /// </summary>
    private static void InitializeMethods() {
      FnMethods = new Dictionary<String, FnMethodGroup>();

      #region Default FnScript API Methods

      #region Addition Methods
      CreateMethodGroup("Add");
      AddMethodToGroup<Int32>("Add", new FnMethod_Add_Int32());
      AddMethodToGroup<UInt32>("Add", new FnMethod_Add_UInt32());
      AddMethodToGroup<Int64>("Add", new FnMethod_Add_Int64());
      AddMethodToGroup<UInt64>("Add", new FnMethod_Add_UInt64());
      AddMethodToGroup<Single>("Add", new FnMethod_Add_Single());
      AddMethodToGroup<Double>("Add", new FnMethod_Add_Double());
      AddMethodToGroup<Decimal>("Add", new FnMethod_Add_Decimal());
      AddMethodToGroup<String>("Add", new FnMethod_Add_String());
      #endregion
      #region Subtraction Methods
      CreateMethodGroup("Subtract");
      AddMethodToGroup<Int32>("Subtract", new FnMethod_Subtract_Int32());
      AddMethodToGroup<UInt32>("Subtract", new FnMethod_Subtract_UInt32());
      AddMethodToGroup<Int64>("Subtract", new FnMethod_Subtract_Int64());
      AddMethodToGroup<UInt64>("Subtract", new FnMethod_Subtract_UInt64());
      AddMethodToGroup<Single>("Subtract", new FnMethod_Subtract_Single());
      AddMethodToGroup<Double>("Subtract", new FnMethod_Subtract_Double());
      AddMethodToGroup<Decimal>("Subtract", new FnMethod_Subtract_Decimal());
      #endregion
      #region Multiplication Methods
      CreateMethodGroup("Multiply");
      AddMethodToGroup<Int32>("Multiply", new FnMethod_Multiply_Int32());
      AddMethodToGroup<UInt32>("Multiply", new FnMethod_Multiply_UInt32());
      AddMethodToGroup<Int64>("Multiply", new FnMethod_Multiply_Int64());
      AddMethodToGroup<UInt64>("Multiply", new FnMethod_Multiply_UInt64());
      AddMethodToGroup<Single>("Multiply", new FnMethod_Multiply_Single());
      AddMethodToGroup<Double>("Multiply", new FnMethod_Multiply_Double());
      AddMethodToGroup<Decimal>("Multiply", new FnMethod_Multiply_Decimal());
      #endregion
      #region Division Methods
      CreateMethodGroup("Divide");
      AddMethodToGroup<Int32>("Divide", new FnMethod_Divide_Int32());
      AddMethodToGroup<UInt32>("Divide", new FnMethod_Divide_UInt32());
      AddMethodToGroup<Int64>("Divide", new FnMethod_Divide_Int64());
      AddMethodToGroup<UInt64>("Divide", new FnMethod_Divide_UInt64());
      AddMethodToGroup<Single>("Divide", new FnMethod_Divide_Single());
      AddMethodToGroup<Double>("Divide", new FnMethod_Divide_Double());
      AddMethodToGroup<Decimal>("Divide", new FnMethod_Divide_Decimal());
      #endregion
      #region Mod Methods
      CreateMethodGroup("Mod");
      AddMethodToGroup<Int32>("Mod", new FnMethod_Mod_Int32());
      AddMethodToGroup<UInt32>("Mod", new FnMethod_Mod_UInt32());
      AddMethodToGroup<Int64>("Mod", new FnMethod_Mod_Int64());
      AddMethodToGroup<UInt64>("Mod", new FnMethod_Mod_UInt64());
      AddMethodToGroup<Single>("Mod", new FnMethod_Mod_Single());
      AddMethodToGroup<Double>("Mod", new FnMethod_Mod_Double());
      AddMethodToGroup<Decimal>("Mod", new FnMethod_Mod_Decimal());
      #endregion

      #region Unary Operator Methods
      #region Positive Methods
      CreateMethodGroup("Positive");
      AddMethodToGroup<Byte>("Positive", new FnMethod_Positive_Byte());
      AddMethodToGroup<SByte>("Positive", new FnMethod_Positive_SByte());
      AddMethodToGroup<Int16>("Positive", new FnMethod_Positive_Int16());
      AddMethodToGroup<UInt16>("Positive", new FnMethod_Positive_UInt16());
      AddMethodToGroup<Int32>("Positive", new FnMethod_Positive_Int32());
      AddMethodToGroup<UInt32>("Positive", new FnMethod_Positive_UInt32());
      AddMethodToGroup<Int64>("Positive", new FnMethod_Positive_Int64());
      AddMethodToGroup<UInt64>("Positive", new FnMethod_Positive_UInt64());
      AddMethodToGroup<Single>("Positive", new FnMethod_Positive_Single());
      AddMethodToGroup<Double>("Positive", new FnMethod_Positive_Double());
      AddMethodToGroup<Decimal>("Positive", new FnMethod_Positive_Decimal());
      #endregion
      #region Negative Methods
      CreateMethodGroup("Negative");
      AddMethodToGroup<SByte>("Negative", new FnMethod_Negative_SByte());
      AddMethodToGroup<Int16>("Negative", new FnMethod_Negative_Int16());
      AddMethodToGroup<Int32>("Negative", new FnMethod_Negative_Int32());
      AddMethodToGroup<Int64>("Negative", new FnMethod_Negative_Int64());
      AddMethodToGroup<Single>("Negative", new FnMethod_Negative_Single());
      AddMethodToGroup<Double>("Negative", new FnMethod_Negative_Double());
      AddMethodToGroup<Decimal>("Negative", new FnMethod_Negative_Decimal());

      AddMethodToGroup<Int16>("Negative", new FnMethod_Negative_Byte());
      AddMethodToGroup<Int32>("Negative", new FnMethod_Negative_UInt16());
      AddMethodToGroup<Int64>("Negative", new FnMethod_Negative_UInt32());
      #endregion
      #region Not Methods
      CreateMethodGroup("Not");
      AddMethodToGroup<Boolean>("Not", new FnMethod_Not_Boolean());
      #endregion
      #endregion

      #region Casting Methods
      #region Byte Casting Methods
      CreateMethodGroup("Byte");
      AddAliasForMethodGroup("Byte", "byte");
      AddMethodToGroup<Byte>("Byte", new FnMethod_Cast_ToByte_FromByte());
      AddMethodToGroup<Byte>("Byte", new FnMethod_Cast_ToByte_FromSByte());
      AddMethodToGroup<Byte>("Byte", new FnMethod_Cast_ToByte_FromInt16());
      AddMethodToGroup<Byte>("Byte", new FnMethod_Cast_ToByte_FromUInt16());
      AddMethodToGroup<Byte>("Byte", new FnMethod_Cast_ToByte_FromInt32());
      AddMethodToGroup<Byte>("Byte", new FnMethod_Cast_ToByte_FromUInt32());
      AddMethodToGroup<Byte>("Byte", new FnMethod_Cast_ToByte_FromInt64());
      AddMethodToGroup<Byte>("Byte", new FnMethod_Cast_ToByte_FromUInt64());

      AddMethodToGroup<Byte>("Byte", new FnMethod_Cast_ToByte_FromSingle());
      AddMethodToGroup<Byte>("Byte", new FnMethod_Cast_ToByte_FromDouble());
      AddMethodToGroup<Byte>("Byte", new FnMethod_Cast_ToByte_FromDecimal());

      AddMethodToGroup<Byte>("Byte", new FnMethod_Cast_ToByte_FromChar());
      AddMethodToGroup<Byte>("Byte", new FnMethod_Cast_ToByte_FromString());

      AddMethodToGroup<Byte>("Byte", new FnMethod_Cast_ToByte_FromObject());
      #endregion
      #region SByte Casting Methods
      CreateMethodGroup("SByte");
      AddAliasForMethodGroup("SByte", "sbyte");
      AddMethodToGroup<SByte>("SByte", new FnMethod_Cast_ToSByte_FromByte());
      AddMethodToGroup<SByte>("SByte", new FnMethod_Cast_ToSByte_FromSByte());
      AddMethodToGroup<SByte>("SByte", new FnMethod_Cast_ToSByte_FromInt16());
      AddMethodToGroup<SByte>("SByte", new FnMethod_Cast_ToSByte_FromUInt16());
      AddMethodToGroup<SByte>("SByte", new FnMethod_Cast_ToSByte_FromInt32());
      AddMethodToGroup<SByte>("SByte", new FnMethod_Cast_ToSByte_FromUInt32());
      AddMethodToGroup<SByte>("SByte", new FnMethod_Cast_ToSByte_FromInt64());
      AddMethodToGroup<SByte>("SByte", new FnMethod_Cast_ToSByte_FromUInt64());

      AddMethodToGroup<SByte>("SByte", new FnMethod_Cast_ToSByte_FromSingle());
      AddMethodToGroup<SByte>("SByte", new FnMethod_Cast_ToSByte_FromDouble());
      AddMethodToGroup<SByte>("SByte", new FnMethod_Cast_ToSByte_FromDecimal());

      AddMethodToGroup<SByte>("SByte", new FnMethod_Cast_ToSByte_FromChar());
      AddMethodToGroup<SByte>("SByte", new FnMethod_CastSByte_FromString());

      AddMethodToGroup<SByte>("SByte", new FnMethod_CastSByte_FromObject());
      #endregion
      #region Int16 Casting Methods
      CreateMethodGroup("Int16");
      AddAliasForMethodGroup("Int16", "short");
      AddMethodToGroup<Int16>("Int16", new FnMethod_Cast_ToInt16_FromByte());
      AddMethodToGroup<Int16>("Int16", new FnMethod_Cast_ToInt16_FromSByte());
      AddMethodToGroup<Int16>("Int16", new FnMethod_Cast_ToInt16_FromInt16());
      AddMethodToGroup<Int16>("Int16", new FnMethod_Cast_ToInt16_FromUInt16());
      AddMethodToGroup<Int16>("Int16", new FnMethod_Cast_ToInt16_FromInt32());
      AddMethodToGroup<Int16>("Int16", new FnMethod_Cast_ToInt16_FromUInt32());
      AddMethodToGroup<Int16>("Int16", new FnMethod_Cast_ToInt16_FromInt64());
      AddMethodToGroup<Int16>("Int16", new FnMethod_Cast_ToInt16_FromUInt64());

      AddMethodToGroup<Int16>("Int16", new FnMethod_Cast_ToInt16_FromSingle());
      AddMethodToGroup<Int16>("Int16", new FnMethod_Cast_ToInt16_FromDouble());
      AddMethodToGroup<Int16>("Int16", new FnMethod_Cast_ToInt16_FromDecimal());

      AddMethodToGroup<Int16>("Int16", new FnMethod_Cast_ToInt16_FromChar());
      AddMethodToGroup<Int16>("Int16", new FnMethod_Cast_ToInt16_FromString());

      AddMethodToGroup<Int16>("Int16", new FnMethod_Cast_ToInt16_FromObject());
      #endregion
      #region UInt16 Casting Methods
      CreateMethodGroup("UInt16");
      AddAliasForMethodGroup("UInt16", "ushort");
      AddMethodToGroup<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromByte());
      AddMethodToGroup<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromSByte());
      AddMethodToGroup<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromInt16());
      AddMethodToGroup<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromUInt16());
      AddMethodToGroup<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromInt32());
      AddMethodToGroup<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromUInt32());
      AddMethodToGroup<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromInt64());
      AddMethodToGroup<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromUInt64());

      AddMethodToGroup<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromSingle());
      AddMethodToGroup<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromDouble());
      AddMethodToGroup<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromDecimal());

      AddMethodToGroup<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromChar());
      AddMethodToGroup<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromString());

      AddMethodToGroup<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromObject());
      #endregion
      #region Int32 Casting Methods
      CreateMethodGroup("Int32");
      AddAliasForMethodGroup("Int32", "int");
      AddMethodToGroup<Int32>("Int32", new FnMethod_Cast_ToInt32_FromByte());
      AddMethodToGroup<Int32>("Int32", new FnMethod_Cast_ToInt32_FromSByte());
      AddMethodToGroup<Int32>("Int32", new FnMethod_Cast_ToInt32_FromInt16());
      AddMethodToGroup<Int32>("Int32", new FnMethod_Cast_ToInt32_FromUInt16());
      AddMethodToGroup<Int32>("Int32", new FnMethod_Cast_ToInt32_FromInt32());
      AddMethodToGroup<Int32>("Int32", new FnMethod_Cast_ToInt32_FromUInt32());
      AddMethodToGroup<Int32>("Int32", new FnMethod_Cast_ToInt32_FromInt64());
      AddMethodToGroup<Int32>("Int32", new FnMethod_Cast_ToInt32_FromUInt64());

      AddMethodToGroup<Int32>("Int32", new FnMethod_Cast_ToInt32_FromSingle());
      AddMethodToGroup<Int32>("Int32", new FnMethod_Cast_ToInt32_FromDouble());
      AddMethodToGroup<Int32>("Int32", new FnMethod_Cast_ToInt32_FromDecimal());

      AddMethodToGroup<Int32>("Int32", new FnMethod_Cast_ToInt32_FromChar());
      AddMethodToGroup<Int32>("Int32", new FnMethod_Cast_ToInt32_FromString());

      AddMethodToGroup<Int32>("Int32", new FnMethod_Cast_ToInt32_FromObject());
      #endregion
      #region UInt32 Casting Methods
      CreateMethodGroup("UInt32");
      AddAliasForMethodGroup("UInt32", "uint");
      AddMethodToGroup<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromByte());
      AddMethodToGroup<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromSByte());
      AddMethodToGroup<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromInt16());
      AddMethodToGroup<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromUInt16());
      AddMethodToGroup<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromInt32());
      AddMethodToGroup<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromUInt32());
      AddMethodToGroup<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromInt64());
      AddMethodToGroup<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromUInt64());

      AddMethodToGroup<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromSingle());
      AddMethodToGroup<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromDouble());
      AddMethodToGroup<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromDecimal());

      AddMethodToGroup<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromChar());
      AddMethodToGroup<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromString());

      AddMethodToGroup<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromObject());
      #endregion
      #region Int64 Casting Methods
      CreateMethodGroup("Int64");
      AddAliasForMethodGroup("Int64", "long");
      AddMethodToGroup<Int64>("Int64", new FnMethod_Cast_ToInt64_FromByte());
      AddMethodToGroup<Int64>("Int64", new FnMethod_Cast_ToInt64_FromSByte());
      AddMethodToGroup<Int64>("Int64", new FnMethod_Cast_ToInt64_FromInt16());
      AddMethodToGroup<Int64>("Int64", new FnMethod_Cast_ToInt64_FromUInt16());
      AddMethodToGroup<Int64>("Int64", new FnMethod_Cast_ToInt64_FromInt32());
      AddMethodToGroup<Int64>("Int64", new FnMethod_Cast_ToInt64_FromUInt32());
      AddMethodToGroup<Int64>("Int64", new FnMethod_Cast_ToInt64_FromInt64());
      AddMethodToGroup<Int64>("Int64", new FnMethod_Cast_ToInt64_FromUInt64());

      AddMethodToGroup<Int64>("Int64", new FnMethod_Cast_ToInt64_FromSingle());
      AddMethodToGroup<Int64>("Int64", new FnMethod_Cast_ToInt64_FromDouble());
      AddMethodToGroup<Int64>("Int64", new FnMethod_Cast_ToInt64_FromDecimal());

      AddMethodToGroup<Int64>("Int64", new FnMethod_Cast_ToInt64_FromChar());
      AddMethodToGroup<Int64>("Int64", new FnMethod_Cast_ToInt64_FromString());

      AddMethodToGroup<Int64>("Int64", new FnMethod_Cast_ToInt64_FromObject());
      #endregion
      #region UInt64 Casting Methods
      CreateMethodGroup("UInt64");
      AddAliasForMethodGroup("UInt64", "ulong");
      AddMethodToGroup<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromByte());
      AddMethodToGroup<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromSByte());
      AddMethodToGroup<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromInt16());
      AddMethodToGroup<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromUInt16());
      AddMethodToGroup<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromInt32());
      AddMethodToGroup<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromUInt32());
      AddMethodToGroup<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromInt64());
      AddMethodToGroup<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromUInt64());

      AddMethodToGroup<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromSingle());
      AddMethodToGroup<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromDouble());
      AddMethodToGroup<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromDecimal());

      AddMethodToGroup<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromChar());
      AddMethodToGroup<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromString());

      AddMethodToGroup<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromObject());
      #endregion
      #region Single Casting Methods
      CreateMethodGroup("Single");
      AddAliasForMethodGroup("Single", "float");
      AddMethodToGroup<Single>("Single", new FnMethod_Cast_ToSingle_FromByte());
      AddMethodToGroup<Single>("Single", new FnMethod_Cast_ToSingle_FromSByte());
      AddMethodToGroup<Single>("Single", new FnMethod_Cast_ToSingle_FromInt16());
      AddMethodToGroup<Single>("Single", new FnMethod_Cast_ToSingle_FromUInt16());
      AddMethodToGroup<Single>("Single", new FnMethod_Cast_ToSingle_FromInt32());
      AddMethodToGroup<Single>("Single", new FnMethod_Cast_ToSingle_FromUInt32());
      AddMethodToGroup<Single>("Single", new FnMethod_Cast_ToSingle_FromInt64());
      AddMethodToGroup<Single>("Single", new FnMethod_Cast_ToSingle_FromUInt64());

      AddMethodToGroup<Single>("Single", new FnMethod_Cast_ToSingle_FromSingle());
      AddMethodToGroup<Single>("Single", new FnMethod_Cast_ToSingle_FromDouble());
      AddMethodToGroup<Single>("Single", new FnMethod_Cast_ToSingle_FromDecimal());

      AddMethodToGroup<Single>("Single", new FnMethod_Cast_ToSingle_FromChar());
      AddMethodToGroup<Single>("Single", new FnMethod_Cast_ToSingle_FromString());

      AddMethodToGroup<Single>("Single", new FnMethod_Cast_ToSingle_FromObject());
      #endregion
      #region Double Casting Methods
      CreateMethodGroup("Double");
      AddAliasForMethodGroup("Double", "double");
      AddMethodToGroup<Double>("Double", new FnMethod_Cast_ToDouble_FromByte());
      AddMethodToGroup<Double>("Double", new FnMethod_Cast_ToDouble_FromSByte());
      AddMethodToGroup<Double>("Double", new FnMethod_Cast_ToDouble_FromInt16());
      AddMethodToGroup<Double>("Double", new FnMethod_Cast_ToDouble_FromUInt16());
      AddMethodToGroup<Double>("Double", new FnMethod_Cast_ToDouble_FromInt32());
      AddMethodToGroup<Double>("Double", new FnMethod_Cast_ToDouble_FromUInt32());
      AddMethodToGroup<Double>("Double", new FnMethod_Cast_ToDouble_FromInt64());
      AddMethodToGroup<Double>("Double", new FnMethod_Cast_ToDouble_FromUInt64());

      AddMethodToGroup<Double>("Double", new FnMethod_Cast_ToDouble_FromSingle());
      AddMethodToGroup<Double>("Double", new FnMethod_Cast_ToDouble_FromDouble());
      AddMethodToGroup<Double>("Double", new FnMethod_Cast_ToDouble_FromDecimal());

      AddMethodToGroup<Double>("Double", new FnMethod_Cast_ToDouble_FromChar());
      AddMethodToGroup<Double>("Double", new FnMethod_Cast_ToDouble_FromString());

      AddMethodToGroup<Double>("Double", new FnMethod_Cast_ToDouble_FromObject());
      #endregion
      #region Decimal Casting Methods
      CreateMethodGroup("Decimal");
      AddAliasForMethodGroup("Decimal", "decimal");
      AddMethodToGroup<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromByte());
      AddMethodToGroup<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromSByte());
      AddMethodToGroup<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromInt16());
      AddMethodToGroup<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromUInt16());
      AddMethodToGroup<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromInt32());
      AddMethodToGroup<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromUInt32());
      AddMethodToGroup<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromInt64());
      AddMethodToGroup<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromUInt64());

      AddMethodToGroup<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromSingle());
      AddMethodToGroup<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromDouble());
      AddMethodToGroup<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromDecimal());

      AddMethodToGroup<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromChar());
      AddMethodToGroup<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromString());

      AddMethodToGroup<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromObject());
      #endregion

      #region Char Casting Methods
      CreateMethodGroup("Char");
      AddAliasForMethodGroup("Char", "char");
      AddMethodToGroup<Char>("Char", new FnMethod_Cast_ToChar_FromByte());
      AddMethodToGroup<Char>("Char", new FnMethod_Cast_ToChar_FromSByte());
      AddMethodToGroup<Char>("Char", new FnMethod_Cast_ToChar_FromInt16());
      AddMethodToGroup<Char>("Char", new FnMethod_Cast_ToChar_FromUInt16());
      AddMethodToGroup<Char>("Char", new FnMethod_Cast_ToChar_FromInt32());
      AddMethodToGroup<Char>("Char", new FnMethod_Cast_ToChar_FromUInt32());
      AddMethodToGroup<Char>("Char", new FnMethod_Cast_ToChar_FromInt64());
      AddMethodToGroup<Char>("Char", new FnMethod_Cast_ToChar_FromUInt64());

      AddMethodToGroup<Char>("Char", new FnMethod_Cast_ToChar_FromSingle());
      AddMethodToGroup<Char>("Char", new FnMethod_Cast_ToChar_FromDouble());
      AddMethodToGroup<Char>("Char", new FnMethod_Cast_ToChar_FromDecimal());

      AddMethodToGroup<Char>("Char", new FnMethod_Cast_ToChar_FromChar());
      AddMethodToGroup<Char>("Char", new FnMethod_Cast_ToChar_FromString());

      AddMethodToGroup<Char>("Char", new FnMethod_Cast_ToChar_FromObject());
      #endregion
      #region String Casting Methods
      CreateMethodGroup("String");
      AddAliasForMethodGroup("String", "string");
      AddMethodToGroup<String>("String", new FnMethod_Cast_ToString_FromString());

      AddMethodToGroup<String>("String", new FnMethod_Cast_ToString_FromObject());
      #endregion
      #region ToString Methods
      CreateMethodGroup("ToString");
      AddMethodToGroup<String>("ToString", new FnMethod_ToString<Byte>());
      AddMethodToGroup<String>("ToString", new FnMethod_ToString<SByte>());
      AddMethodToGroup<String>("ToString", new FnMethod_ToString<Int16>());
      AddMethodToGroup<String>("ToString", new FnMethod_ToString<UInt16>());
      AddMethodToGroup<String>("ToString", new FnMethod_ToString<Int32>());
      AddMethodToGroup<String>("ToString", new FnMethod_ToString<UInt32>());
      AddMethodToGroup<String>("ToString", new FnMethod_ToString<Int64>());
      AddMethodToGroup<String>("ToString", new FnMethod_ToString<UInt64>());

      AddMethodToGroup<String>("ToString", new FnMethod_ToString<Single>());
      AddMethodToGroup<String>("ToString", new FnMethod_ToString<Double>());
      AddMethodToGroup<String>("ToString", new FnMethod_ToString<Decimal>());

      AddMethodToGroup<String>("ToString", new FnMethod_ToString<Char>());
      AddMethodToGroup<String>("ToString", new FnMethod_ToString<String>());

      AddMethodToGroup<String>("ToString", new FnMethod_ToString<Object>());
      #endregion

      #region Int32? Casting Methods
      CreateMethodGroup("NullableInt32");
      AddMethodToGroup<Int32?>("NullableInt32", new FnMethod_ToNullableInt32_FromNull());
      #endregion

      #region Object Casting Methods
      CreateMethodGroup("Object");
      AddAliasForMethodGroup("Object", "object");
      AddMethodToGroup<Object>("Object", new FnMethod_Cast_ToObject_FromObject());
      #endregion
      #endregion
      #region Implicit Conversion Methods

      //#region Int32? Implicit Conversion Methods
      // There's an issue with this, but I don't remember what it is... Something about FnScript not being able to determine the correct overload when passing a struct to a method which accepts Nullable<struct>?
      //AddSwitch("ImplicitToNullableInt32", new List<CompileFlags> { CompileFlags.IMPLICIT_CONVERSION });
      //AddMethodToGroup<Int32?>("ImplicitToNullableInt32", ImplicitToNullableInt32_FromChar, new List<Type> { typeof(Char) });
      //AddMethodToGroup<Int32?>("ImplicitToNullableInt32", ImplicitToNullableInt32_FromByte, new List<Type> { typeof(Byte) });
      //AddMethodToGroup<Int32?>("ImplicitToNullableInt32", ImplicitToNullableInt32_FromSByte, new List<Type> { typeof(SByte) });
      //AddMethodToGroup<Int32?>("ImplicitToNullableInt32", ImplicitToNullableInt32_FromInt16, new List<Type> { typeof(Int16) });
      //AddMethodToGroup<Int32?>("ImplicitToNullableInt32", ImplicitToNullableInt32_FromUInt16, new List<Type> { typeof(UInt16) });
      //AddMethodToGroup<Int32?>("ImplicitToNullableInt32", ImplicitToNullableInt32_FromInt32, new List<Type> { typeof(Int32) });
      //AddMethodToGroup<Int32?>("ImplicitToNullableInt32", ImplicitToNullableInt32_FromNull, new List<Type> { typeof(Object) });
      //#endregion
      #endregion

      #region Comparison Methods
      #region IsGreaterThan Methods
      CreateMethodGroup("IsGreaterThan");
      AddMethodToGroup<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_Byte());
      AddMethodToGroup<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_SByte());
      AddMethodToGroup<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_Int16());
      AddMethodToGroup<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_UInt16());
      AddMethodToGroup<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_Int32());
      AddMethodToGroup<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_UInt32());
      AddMethodToGroup<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_Int64());
      AddMethodToGroup<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_UInt64());
      AddMethodToGroup<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_Single());
      AddMethodToGroup<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_Double());
      AddMethodToGroup<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_Decimal());

      AddMethodToGroup<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_Char());
      #endregion
      #region IsGreaterThanOrEqual Methods
      CreateMethodGroup("IsGreaterThanOrEqual");
      AddMethodToGroup<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_Byte());
      AddMethodToGroup<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_SByte());
      AddMethodToGroup<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_Int16());
      AddMethodToGroup<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_UInt16());
      AddMethodToGroup<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_Int32());
      AddMethodToGroup<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_UInt32());
      AddMethodToGroup<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_Int64());
      AddMethodToGroup<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_UInt64());
      AddMethodToGroup<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_Single());
      AddMethodToGroup<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_Double());
      AddMethodToGroup<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_Decimal());

      AddMethodToGroup<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_Char());
      #endregion
      #region IsLessThan Methods
      CreateMethodGroup("IsLessThan");
      AddMethodToGroup<Boolean>("IsLessThan", new FnMethod_IsLessThan_Byte());
      AddMethodToGroup<Boolean>("IsLessThan", new FnMethod_IsLessThan_SByte());
      AddMethodToGroup<Boolean>("IsLessThan", new FnMethod_IsLessThan_Int16());
      AddMethodToGroup<Boolean>("IsLessThan", new FnMethod_IsLessThan_UInt16());
      AddMethodToGroup<Boolean>("IsLessThan", new FnMethod_IsLessThan_Int32());
      AddMethodToGroup<Boolean>("IsLessThan", new FnMethod_IsLessThan_UInt32());
      AddMethodToGroup<Boolean>("IsLessThan", new FnMethod_IsLessThan_Int64());
      AddMethodToGroup<Boolean>("IsLessThan", new FnMethod_IsLessThan_UInt64());
      AddMethodToGroup<Boolean>("IsLessThan", new FnMethod_IsLessThan_Single());
      AddMethodToGroup<Boolean>("IsLessThan", new FnMethod_IsLessThan_Double());
      AddMethodToGroup<Boolean>("IsLessThan", new FnMethod_IsLessThan_Decimal());

      AddMethodToGroup<Boolean>("IsLessThan", new FnMethod_IsLessThan_Char());
      #endregion
      #region IsLessThanOrEqual Methods
      CreateMethodGroup("IsLessThanOrEqual");
      AddMethodToGroup<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_Byte());
      AddMethodToGroup<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_SByte());
      AddMethodToGroup<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_Int16());
      AddMethodToGroup<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_UInt16());
      AddMethodToGroup<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_Int32());
      AddMethodToGroup<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_UInt32());
      AddMethodToGroup<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_Int64());
      AddMethodToGroup<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_UInt64());
      AddMethodToGroup<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_Single());
      AddMethodToGroup<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_Double());
      AddMethodToGroup<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_Decimal());

      AddMethodToGroup<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_Char());
      #endregion
      #region IsEqual Methods
      CreateMethodGroup("IsEqual");
      AddMethodToGroup<Boolean>("IsEqual", new FnMethod_IsEqual_Byte());
      AddMethodToGroup<Boolean>("IsEqual", new FnMethod_IsEqual_SByte());
      AddMethodToGroup<Boolean>("IsEqual", new FnMethod_IsEqual_Int16());
      AddMethodToGroup<Boolean>("IsEqual", new FnMethod_IsEqual_UInt16());
      AddMethodToGroup<Boolean>("IsEqual", new FnMethod_IsEqual_Int32());
      AddMethodToGroup<Boolean>("IsEqual", new FnMethod_IsEqual_UInt32());
      AddMethodToGroup<Boolean>("IsEqual", new FnMethod_IsEqual_Int64());
      AddMethodToGroup<Boolean>("IsEqual", new FnMethod_IsEqual_UInt64());
      AddMethodToGroup<Boolean>("IsEqual", new FnMethod_IsEqual_Single());
      AddMethodToGroup<Boolean>("IsEqual", new FnMethod_IsEqual_Double());
      AddMethodToGroup<Boolean>("IsEqual", new FnMethod_IsEqual_Decimal());

      AddMethodToGroup<Boolean>("IsEqual", new FnMethod_IsEqual_Char());
      AddMethodToGroup<Boolean>("IsEqual", new FnMethod_IsEqual_String());

      AddMethodToGroup<Boolean>("IsEqual", new FnMethod_IsEqual_Boolean());

      AddMethodToGroup<Boolean>("IsEqual", new FnMethod_IsEqual_Object());
      #endregion
      #region IsNotEqualMethods
      CreateMethodGroup("IsNotEqual");
      AddMethodToGroup<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_Byte());
      AddMethodToGroup<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_SByte());
      AddMethodToGroup<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_Int16());
      AddMethodToGroup<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_UInt16());
      AddMethodToGroup<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_Int32());
      AddMethodToGroup<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_UInt32());
      AddMethodToGroup<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_Int64());
      AddMethodToGroup<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_UInt64());
      AddMethodToGroup<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_Single());
      AddMethodToGroup<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_Double());
      AddMethodToGroup<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_Decimal());

      AddMethodToGroup<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_Char());
      AddMethodToGroup<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_String());

      AddMethodToGroup<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_Boolean());

      AddMethodToGroup<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_Object());
      #endregion
      #region And Methods
      CreateMethodGroup("And");
      AddMethodToGroup<Boolean>("And", new FnMethod_And());
      #endregion
      #region Nand Methods
      CreateMethodGroup("Nand");
      AddMethodToGroup<Boolean>("Nand", new FnMethod_Nand());
      #endregion
      #region Or Methods
      CreateMethodGroup("Or");
      AddMethodToGroup<Boolean>("Or", new FnMethod_Or());
      #endregion
      #region Nor Methods
      CreateMethodGroup("Nor");
      AddMethodToGroup<Boolean>("Nor", new FnMethod_Nor());
      #endregion
      #region Xor Methods
      CreateMethodGroup("Xor");
      AddMethodToGroup<Boolean>("Xor", new FnMethod_Xor());
      #endregion
      #endregion

      #region Void Method Wrappers
      CreateMethodGroup("Return");

      // Add multiple void methods as arguments overloads (2 void methods, 3 void methods, etc...).
      AddMethodToGroup<Byte>("Return", new FnMethod_Return<Byte>());
      AddMethodToGroup<SByte>("Return", new FnMethod_Return<SByte>());
      AddMethodToGroup<Int16>("Return", new FnMethod_Return<Int16>());
      AddMethodToGroup<UInt16>("Return", new FnMethod_Return<UInt16>());
      AddMethodToGroup<Int32>("Return", new FnMethod_Return<Int32>());
      AddMethodToGroup<UInt32>("Return", new FnMethod_Return<UInt32>());
      AddMethodToGroup<Int64>("Return", new FnMethod_Return<Int64>());
      AddMethodToGroup<UInt64>("Return", new FnMethod_Return<UInt64>());
      AddMethodToGroup<Single>("Return", new FnMethod_Return<Single>());
      AddMethodToGroup<Double>("Return", new FnMethod_Return<Double>());
      AddMethodToGroup<Decimal>("Return", new FnMethod_Return<Decimal>());

      AddMethodToGroup<Char>("Return", new FnMethod_Return<Char>());
      AddMethodToGroup<String>("Return", new FnMethod_Return<String>());

      AddMethodToGroup<Object>("Return", new FnMethod_Return<Object>());
      #endregion

      #region Nullable Types Helper Methods
      CreateMethodGroup("IsNull");
      AddMethodToGroup<Boolean>("IsNull", new FnMethod_IsNull());

      #region Nullable GetValue Methods
      CreateMethodGroup("GetValue");
      AddMethodToGroup<Byte>("GetValue", new FnMethod_GetValue<Byte>());
      AddMethodToGroup<SByte>("GetValue", new FnMethod_GetValue<SByte>());
      AddMethodToGroup<Int16>("GetValue", new FnMethod_GetValue<Int16>());
      AddMethodToGroup<UInt16>("GetValue", new FnMethod_GetValue<UInt16>());
      AddMethodToGroup<Int32>("GetValue", new FnMethod_GetValue<Int32>());
      AddMethodToGroup<UInt32>("GetValue", new FnMethod_GetValue<UInt32>());
      AddMethodToGroup<Int64>("GetValue", new FnMethod_GetValue<Int64>());
      AddMethodToGroup<UInt64>("GetValue", new FnMethod_GetValue<UInt64>());
      AddMethodToGroup<Single>("GetValue", new FnMethod_GetValue<Single>());
      AddMethodToGroup<Double>("GetValue", new FnMethod_GetValue<Double>());
      AddMethodToGroup<Decimal>("GetValue", new FnMethod_GetValue<Decimal>());
      AddMethodToGroup<Char>("GetValue", new FnMethod_GetValue<Char>());
      #endregion
      #endregion

      #region .Net Math Wrapper Methods
      #region Math.Abs
      CreateMethodGroup("Abs");
      AddMethodToGroup<Decimal>("Abs", new FnMethod_Abs_Decimal());
      AddMethodToGroup<Double>("Abs", new FnMethod_Abs_Double());
      AddMethodToGroup<Single>("Abs", new FnMethod_Abs_Single());
      AddMethodToGroup<Int64>("Abs", new FnMethod_Abs_Int64());
      AddMethodToGroup<Int32>("Abs", new FnMethod_Abs_Int32());
      AddMethodToGroup<Int16>("Abs", new FnMethod_Abs_Int16());
      AddMethodToGroup<SByte>("Abs", new FnMethod_Abs_SByte());
      #endregion
      #region Math.Acos
      CreateMethodGroup("Acos");
      AddMethodToGroup<Double>("Acos", new FnMethod_Acos_Double());
      AddMethodToGroup<Single>("Acos", new FnMethod_Acos_Single());
      #endregion
      #region Math.Asin
      CreateMethodGroup("Asin");
      AddMethodToGroup<Double>("Asin", new FnMethod_Asin_Double());
      AddMethodToGroup<Single>("Asin", new FnMethod_Asin_Single());
      #endregion
      #region Math.Atan
      CreateMethodGroup("Atan");
      AddMethodToGroup<Double>("Atan", new FnMethod_Atan_Double());
      AddMethodToGroup<Single>("Atan", new FnMethod_Atan_Single());
      #endregion
      #region Math.Atan2
      CreateMethodGroup("Atan2");
      AddMethodToGroup<Single>("Atan2", new FnMethod_Atan2_Single());
      AddMethodToGroup<Double>("Atan2", new FnMethod_Atan2_Double());
      #endregion
      #region Math.Ceiling
      CreateMethodGroup("Ceiling");
      AddMethodToGroup<Single>("Ceiling", new FnMethod_Ceiling_Single());
      AddMethodToGroup<Double>("Ceiling", new FnMethod_Ceiling_Double());
      #endregion
      #region Math.Cos
      CreateMethodGroup("Cos");
      AddMethodToGroup<Single>("Cos", new FnMethod_Cos_Single());
      AddMethodToGroup<Double>("Cos", new FnMethod_Cos_Double());
      #endregion
      #region Math.Cosh
      CreateMethodGroup("Cosh");
      AddMethodToGroup<Single>("Cosh", new FnMethod_Cosh_Single());
      AddMethodToGroup<Double>("Cosh", new FnMethod_Cosh_Double());
      #endregion
      #region Math.Exp
      CreateMethodGroup("Exp");
      AddMethodToGroup<Int32>("Exp", new FnMethod_Exp_Int32());
      AddMethodToGroup<UInt32>("Exp", new FnMethod_Exp_UInt32());
      AddMethodToGroup<Int64>("Exp", new FnMethod_Exp_Int64());
      AddMethodToGroup<UInt64>("Exp", new FnMethod_Exp_UInt64());
      AddMethodToGroup<Single>("Exp", new FnMethod_Exp_Single());
      AddMethodToGroup<Double>("Exp", new FnMethod_Exp_Double());
      #endregion
      #region Math.Floor
      CreateMethodGroup("Floor");
      AddMethodToGroup<Single>("Floor", new FnMethod_Floor_Single());
      AddMethodToGroup<Double>("Floor", new FnMethod_Floor_Double());
      #endregion
      #region Math.IEEERemainder
      CreateMethodGroup("IEEERemainder");
      AddMethodToGroup<Double>("IEEERemainder", new FnMethod_IEEERemainder());
      #endregion
      #region Math.Log
      CreateMethodGroup("Log");
      AddMethodToGroup<Single>("Log", new FnMethod_Log_BaseE_Single());
      AddMethodToGroup<Double>("Log", new FnMethod_Log_BaseE_Double());
      AddMethodToGroup<Single>("Log", new FnMethod_Log_CustomBase_Single());
      AddMethodToGroup<Double>("Log", new FnMethod_Log_CustomBase_Double());
      #endregion
      #region Math.Log10
      CreateMethodGroup("Log10");
      AddMethodToGroup<Single>("Log10", new FnMethod_Log10_Single());
      AddMethodToGroup<Double>("Log10", new FnMethod_Log10_Double());
      #endregion
      #region Math.Max
      CreateMethodGroup("Max");
      AddMethodToGroup<Byte>("Max", new FnMethod_Max_Byte());
      AddMethodToGroup<SByte>("Max", new FnMethod_Max_SByte());
      AddMethodToGroup<Int16>("Max", new FnMethod_Max_Int16());
      AddMethodToGroup<UInt16>("Max", new FnMethod_Max_UInt16());
      AddMethodToGroup<Int32>("Max", new FnMethod_Max_Int32());
      AddMethodToGroup<UInt32>("Max", new FnMethod_Max_UInt32());
      AddMethodToGroup<Int64>("Max", new FnMethod_Max_Int64());
      AddMethodToGroup<UInt64>("Max", new FnMethod_Max_UInt64());
      AddMethodToGroup<Single>("Max", new FnMethod_Max_Single());
      AddMethodToGroup<Double>("Max", new FnMethod_Max_Double());
      AddMethodToGroup<Decimal>("Max", new FnMethod_Max_Decimal());
      #endregion
      #region Math.Min
      CreateMethodGroup("Min");
      AddMethodToGroup<Byte>("Min", new FnMethod_Min_Byte());
      AddMethodToGroup<SByte>("Min", new FnMethod_Min_SByte());
      AddMethodToGroup<Int16>("Min", new FnMethod_Min_Int16());
      AddMethodToGroup<UInt16>("Min", new FnMethod_Min_UInt16());
      AddMethodToGroup<Int32>("Min", new FnMethod_Min_Int32());
      AddMethodToGroup<UInt32>("Min", new FnMethod_Min_UInt32());
      AddMethodToGroup<Int64>("Min", new FnMethod_Min_Int64());
      AddMethodToGroup<UInt64>("Min", new FnMethod_Min_UInt64());
      AddMethodToGroup<Single>("Min", new FnMethod_Min_Single());
      AddMethodToGroup<Double>("Min", new FnMethod_Min_Double());
      AddMethodToGroup<Decimal>("Min", new FnMethod_Min_Decimal());
      #endregion
      #region Math.Pow
      CreateMethodGroup("Pow");
      AddMethodToGroup<Int32>("Pow", new FnMethod_Pow_Int32());
      AddMethodToGroup<UInt32>("Pow", new FnMethod_Pow_UInt32());
      AddMethodToGroup<Int64>("Pow", new FnMethod_Pow_Int64());
      AddMethodToGroup<UInt64>("Pow", new FnMethod_Pow_UInt64());
      AddMethodToGroup<Double>("Pow", new FnMethod_Pow_Double());
      #endregion
      #region Math.Round
      CreateMethodGroup("Round");
      AddMethodToGroup<Single>("Round", new FnMethod_Round_Single_1());
      AddMethodToGroup<Double>("Round", new FnMethod_Round_Double_1());
      AddMethodToGroup<Decimal>("Round", new FnMethod_Round_Decimal_1());

      AddMethodToGroup<Single>("Round", new FnMethod_Round_Single_2());
      AddMethodToGroup<Double>("Round", new FnMethod_Round_Double_2());
      AddMethodToGroup<Decimal>("Round", new FnMethod_Round_Decimal_2());
      #endregion
      #region Math.Sign
      CreateMethodGroup("Sign");
      AddMethodToGroup<Int32>("Sign", new FnMethod_Sign_Decimal());
      AddMethodToGroup<Int32>("Sign", new FnMethod_Sign_Double());
      AddMethodToGroup<Int32>("Sign", new FnMethod_Sign_Single());
      AddMethodToGroup<Int32>("Sign", new FnMethod_Sign_Int64());
      AddMethodToGroup<Int32>("Sign", new FnMethod_Sign_Int32());
      AddMethodToGroup<Int32>("Sign", new FnMethod_Sign_Int16());
      AddMethodToGroup<Int32>("Sign", new FnMethod_Sign_SByte());
      #endregion
      #region Math.Sin
      CreateMethodGroup("Sin");
      AddMethodToGroup<Single>("Sin", new FnMethod_Sin_Single());
      AddMethodToGroup<Double>("Sin", new FnMethod_Sin_Double());
      #endregion
      #region Math.Sinh
      CreateMethodGroup("Sinh");
      AddMethodToGroup<Single>("Sinh", new FnMethod_Sinh_Single());
      AddMethodToGroup<Double>("Sinh", new FnMethod_Sinh_Double());
      #endregion
      #region Math.Sqrt
      CreateMethodGroup("Sqrt");
      AddMethodToGroup<Single>("Sqrt", new FnMethod_Sqrt_Single());
      AddMethodToGroup<Double>("Sqrt", new FnMethod_Sqrt_Double());
      #endregion
      #region Math.Tan
      CreateMethodGroup("Tan");
      AddMethodToGroup<Single>("Tan", new FnMethod_Tan_Single());
      AddMethodToGroup<Double>("Tan", new FnMethod_Tan_Double());
      #endregion
      #region Math.Tanh
      CreateMethodGroup("Tanh");
      AddMethodToGroup<Single>("Tanh", new FnMethod_Tanh_Single());
      AddMethodToGroup<Double>("Tanh", new FnMethod_Tanh_Double());
      #endregion
      #endregion

      #region Bezier Curve Methods
      CreateMethodGroup("BezierCurve");
      AddMethodToGroup<Single>("BezierCurve", new FnMethod_Bezier_Quadratic_Single());
      AddMethodToGroup<Double>("BezierCurve", new FnMethod_Bezier_Quadratic_Double());
      AddMethodToGroup<Single>("BezierCurve", new FnMethod_Bezier_Cubic_Single());
      AddMethodToGroup<Double>("BezierCurve", new FnMethod_Bezier_Cubic_Double());
      #endregion

      #region Other Maths Methods
      #region Cycle
      CreateMethodGroup("Cycle");
      AddMethodToGroup<Int32>("Cycle", new FnMethod_Cycle_Int32());
      AddMethodToGroup<Single>("Cycle", new FnMethod_Cycle_Single());
      #endregion
      #region RandomInt
      CreateMethodGroup("RandomInt");
      AddMethodToGroup<Int32>("RandomInt", new FnMethod_RandomInt());
      AddMethodToGroup<Int32>("RandomInt", new FnMethod_RandomInt_Max());
      AddMethodToGroup<Int32>("RandomInt", new FnMethod_RandomInt_Min_Max());
      #endregion
      #endregion

      #region FnObject Parameter Methods
      CreateMethodGroup("SetParameter");
      AddMethodToGroup<Object>("SetParameter", new FnMethod_SetParameter<Byte>());
      AddMethodToGroup<Object>("SetParameter", new FnMethod_SetParameter<SByte>());
      AddMethodToGroup<Object>("SetParameter", new FnMethod_SetParameter<Int16>());
      AddMethodToGroup<Object>("SetParameter", new FnMethod_SetParameter<UInt16>());
      AddMethodToGroup<Object>("SetParameter", new FnMethod_SetParameter<Int32>());
      AddMethodToGroup<Object>("SetParameter", new FnMethod_SetParameter<UInt32>());
      AddMethodToGroup<Object>("SetParameter", new FnMethod_SetParameter<Int64>());
      AddMethodToGroup<Object>("SetParameter", new FnMethod_SetParameter<UInt64>());
      AddMethodToGroup<Object>("SetParameter", new FnMethod_SetParameter<Single>());
      AddMethodToGroup<Object>("SetParameter", new FnMethod_SetParameter<Double>());
      AddMethodToGroup<Object>("SetParameter", new FnMethod_SetParameter<Decimal>());
      AddMethodToGroup<Object>("SetParameter", new FnMethod_SetParameter<Char>());
      AddMethodToGroup<Object>("SetParameter", new FnMethod_SetParameter<String>());

      //This method won't provide universal Parameter setting available for all data types,
      //but it's required to get setting parameters of data type "object" to work
      AddMethodToGroup<Object>("SetParameter", new FnMethod_SetParameter<Object>());

      AddMethodToGroup<Object>("SetParameter", new FnMethod_SetParameter<Int32?>());
      #endregion

      #region String Methods
      #region String Class Wrapper Methods
      #region SubString
      CreateMethodGroup("SubString");
      AddMethodToGroup<String>("SubString", new FnMethod_SubString_StartOnly());
      AddMethodToGroup<String>("SubString", new FnMethod_SubString_StartAndEnd());
      #endregion
      #endregion
      #region Custom String Methods
      #region RandomString
      CreateMethodGroup("RandomString");
      AddMethodToGroup<String>("RandomString", new FnMethod_RandomString_WithoutPrefix());
      AddMethodToGroup<String>("RandomString", new FnMethod_RandomString_WithPrefix());
      #endregion
      #region LengthOf
      CreateMethodGroup("LengthOf");
      AddMethodToGroup<Int32>("LengthOf", new FnMethod_LengthOf());
      #endregion
      #region CharAt
      CreateMethodGroup("CharAt");
      AddMethodToGroup<Char>("CharAt", new FnMethod_CharAt());
      #endregion
      #region Reverse
      CreateMethodGroup("Reverse");
      AddMethodToGroup<String>("Reverse", new FnMethod_Reverse());
      #endregion
      #endregion
      #endregion

      #endregion
    }

    /// <summary>
    /// Initializes default global parameters. Any default global parameters should be placed here.
    /// </summary>
    private static void InitializeGlobalParameters() {
    }

    #region Global Parameter Modification Methods

    /// <summary>
    /// Defines a global parameter, initialized with the specified value.
    /// </summary>
    /// <typeparam name="TInput">The data type of the global parameter</typeparam>
    /// <param name="parameterName">The name to assign to the global parameter</param>
    /// <param name="parameterValue">The value to initialize the new parameter with</param>
    public static void AddGlobalParameter<TInput>(String parameterName, TInput parameterValue) {
      if (!GlobalParameters.ContainsKey(parameterName)) {
        GlobalParameters.Add(parameterName, new FnVariable<TInput>(parameterValue));
      } else {
        throw new ArgumentException(String.Format("Parameter of name \"{0}\" already exist.", parameterName));
      }
    }

    /// <summary>
    /// Sets the value of a specified global parameter with a specified value
    /// </summary>
    /// <typeparam name="TInput">The data type of the global parameter</typeparam>
    /// <param name="parameterName">The name of the global parameter</param>
    /// <param name="parameterValue">The value to assign to the global parameter</param>
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
        throw new ArgumentException(String.Format("Parameter of name \"{0}\" doesn't exist.", parameterName));
      }
    }

    /// <summary>
    /// Removes the global parameter with the specified name.
    /// </summary>
    /// <param name="parameterName">The name of the parameter to remove from the global parameters list</param>
    public static void RemoveGlobalParameter(String parameterName) {
      if (GlobalParameters.ContainsKey(parameterName)) {
        GlobalParameters.Remove(parameterName);
      } else {
        throw new ArgumentException("Parameter of name \"{0}\" doesn't exist.", parameterName);
      }
    }

    #endregion

    /// <summary>
    /// Adds a constant to the FnScript list of constants with the specified name and value
    /// </summary>
    /// <typeparam name="T">The data type of the constant</typeparam>
    /// <param name="name">The name of the constant</param>
    /// <param name="data">The value to initialize it with</param>
    public static void AddConstant<T>(String name, T data) {
      //check the validity of the constant name, constants can only be made of letters, digits or underscores, and must start with a letter or an underscore
      if (IsValidName(name)) {
        Constants.Add(name, new FnConstant<T>(data));
      } else {
        throw new ArgumentException("Invalid constant name provided. Names for constants can only contain underscores, letters or digits, must start with an underscore or a letter, and must not be blank");
      }
    }

    /// <summary>
    /// Creates a new FnMethodSwitch with the specified name and adds it to the list of callable methods from FnScript
    /// </summary>
    /// <param name="name">The name of the switch</param>
    /// <param name="compileFlags">A list of compile flags to add to the switch, which are propagated to any FnObject that is built using the switch</param>
    public static void CreateMethodGroup(String name) {
      if (IsValidName(name) && !FnMethods.ContainsKey(name)) {
        FnMethods.Add(name, new FnMethodGroup(name));
      } else {
        throw new ArgumentException("Invalid method name provided. Names for switches can only contain underscores, letters or digits, must start with an underscore or a letter, and must not be blank");
      }
    }

    /// <summary>
    /// Creates an alias which references a switch. Changes made to the switch at any time are reflected in the alias
    /// </summary>
    /// <param name="switchName">The name of the method switch to alias</param>
    /// <param name="Alias">The alias to use</param>
    public static void AddAliasForMethodGroup(String switchName, String alias) {
      if (IsValidName(alias) && !FnMethods.ContainsKey(alias)) {
        FnMethods.Add(alias, FnMethods[switchName]);
      } else {
        throw new ArgumentException("Invalid alias name provided. Aliases for switches can only contain underscores, letters or digits, must start with an underscore or a letter, and must not be blank", switchName);
      }
    }

    /// <summary>
    /// Adds an <see cref="FnMethod"/> to the method group of the provided name.
    /// </summary>
    /// <typeparam name="T">The return type of the method pointer</typeparam>
    /// <param name="name">The name of the switch to add it to</param>
    /// <param name="pointer">The pointer to the method itself</param>
    public static void AddMethodToGroup<T>(String name, FnMethod<T> pointer) {
      if (FnMethods.ContainsKey(name)) {
        FnMethods[name].AddMethodPointer(new FnMethodPointer<T>(pointer));
        // We do check for an overload conflict, but instead of doing it here it's done in the
        // FnMethodSwitch.AddMethodPointer() method.
      } else {
        throw new ArgumentException("Invalid method name provided. A method switch by this name does not exist");
      }

      //If this method has an implicit conversion flag
      if (pointer.Flags != null && pointer.Flags.Contains(FnMethod<T>.CompileFlags.IMPLICIT_CONVERSION)) {
        if (pointer.ArgumentTypes == null || pointer.ArgumentTypes.Length > 1 || pointer.ArgumentTypes.Length == 0) {
          throw new ArgumentException(
            "The FnMethod provided has the incorrect number of parameters. To be a valid Implicit Converion method it" +
            "must have exactly one parameter."
          );
        }

        //We have now established that the implicit conversion method provided accepts exactly one method argument. Now we have to determine
        //if it can be added to the list of implicit conversion switches

        //If we don't have an implicit conversion switch for this data type yet, create it.
        if (!ImplicitConversionSwitches.ContainsKey(typeof(T))) {
          ImplicitConversionSwitches.Add(typeof(T), new FnMethodGroup("ImplicitTo_" + typeof(T)));
        }

        //Now we check to see if this implicit conversion has been handled already, by looping through the methods in that
        //switch and checking their input parameter type
        foreach (FnMethodPointer m in ImplicitConversionSwitches[typeof(T)].MethodPointers) {
          if (m.GetMethodTypeArray()[0] == pointer.ArgumentTypes[0]) {
            throw new ArgumentException(
              "The implicit conversion specified is already handled by another FnMethod", pointer.ToString()
            );
          }
        }

        //If we are successful, add the FnMethod to the implicit conversion switch
        ImplicitConversionSwitches[typeof(T)].AddMethodPointer(new FnMethodPointer<T>(pointer));
      }
    }

    /// <summary>
    /// Returns the ambiguity score of a provided argument type versus the desired argument type. The higher the
    /// ambiguity score, the more ambiguous the method call is. If a score of -1 is returned, then you cannot implicitly
    /// convert between the two types.
    /// </summary>
    /// <param name="methodType">The parameter type for the method</param>
    /// <param name="argumentType">The data type of the provided argument</param>
    /// <returns></returns>
    internal static Int32 GetAmbiguityScore(Type methodType, Type argumentType) {
      // If the method type can be ambiguous.
      if (TypePrecedence.ContainsKey(methodType)) {
        if (TypePrecedence.ContainsKey(argumentType)) {
          if (TypePrecedence[methodType] % 2 == 0)    //if we have a signed method data type
          {
            if ((TypePrecedence[argumentType] % 2 == 1) && (TypePrecedence[argumentType] > TypePrecedence[methodType]))     //if we have an unsigned argument data type this is higher precedence than the method type
            {
              return -1;
            }
          }

          return TypePrecedence[methodType] - TypePrecedence[argumentType];
        } else {
          if (argumentType == typeof(Char))  //if it's a char then we have to do some weird stuff
          {
            return TypePrecedence[methodType] - TypePrecedence[typeof(UInt16)];
          } else //if it's anything else, give it ambiguity level 13 and return the result
            {
            return TypePrecedence[methodType] - 13;      // 13'S A MAGIC NUMBER BUT IT'S THERE BECAUSE THAT'S THE GAP THAT WAS LEFT BETWEEN DECIMAL AND OBJECT FOR AMBIGUITY SCORES
          }
        }
      } else {
        return -1;
      }
    }

    /// <summary>
    /// Determines if the string specified is a valid name for a Method or Constant to be used in FnScript.
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
    /// Determines if a constant with the specified name exists.
    /// </summary>
    /// <param name="name">The name to verify.</param>
    /// <returns></returns>
    public static Boolean DoesConstantExist(String name) {
      return Constants.ContainsKey(name);
    }

    /// <summary>
    /// Determines if an FnMethodSwitch with the spedified name exists.
    /// </summary>
    /// <param name="name">The name to verify</param>
    /// <returns></returns>
    public static Boolean DoesMethodExist(String name) {
      return FnMethods.ContainsKey(name);
    }

    /// <summary>
    /// Returns the FnMethodSwitch with the specified name.
    /// </summary>
    /// <param name="name">The name of the method</param>
    /// <returns></returns>
    internal static FnMethodGroup GetMethod(String name) {
      if (DoesMethodExist(name)) { return FnMethods[name]; }
      throw new ArgumentException("The method you have requested (" + name + ") does not exist");
    }

    /// <summary>
    /// Returns the FnObject containing the constant with the specified name
    /// </summary>
    /// <param name="name">The name of the constant</param>
    /// <returns></returns>
    public static FnObject GetConstant(String name) {
      if (DoesConstantExist(name)) { return Constants[name]; }
      throw new ArgumentException("The constant you have requested (" + name + ") does not exist");
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
