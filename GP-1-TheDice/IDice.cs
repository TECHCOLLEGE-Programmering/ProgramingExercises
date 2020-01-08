using System;
namespace Dice {
    /**
    DO NOT MODIFY
    This is a Dice interface. It guarantees that dices you add have a Roll() and Name() method
    **/
    interface IDice {
        int Roll();
        string Name();
    }
}