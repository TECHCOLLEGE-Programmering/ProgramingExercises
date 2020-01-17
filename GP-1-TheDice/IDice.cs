using System;
namespace Dice
{
    /// <summary>
    /// DO NOT MODIFY
    /// This is a Dice interface. It guarantees that dices you add have a Roll() and Name() method
    /// </summary>
    interface IDice {
        int Roll();
        string Name();
    }
}