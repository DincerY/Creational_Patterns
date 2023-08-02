

Example ex = Example.GetInstance;


class Example
{
    private Example()
    {
        Console.WriteLine($"{nameof(Example)} nesnesi oluşturuldu");
    }

    #region 1.Yöntem
    //private static Example _example;
    //public static Example GetInstance
    //{
    //    get
    //    {
    //        if (_example == null)
    //        {
    //            _example = new Example();
    //        }
    //        return _example;
    //    }
    //}
    #endregion

    #region 2.Yöntem
    private static Example _example;

    static Example()
    {
        _example = new Example();
    }
    public static Example GetInstance
    {
        get
        {
            return _example;
        }
    }

    #endregion

}


