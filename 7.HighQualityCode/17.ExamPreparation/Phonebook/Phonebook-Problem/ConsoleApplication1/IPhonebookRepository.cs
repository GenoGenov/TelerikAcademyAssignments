namespace ConsoleApplication1
{
    using System.Collections.Generic;

    internal interface IPhonebookRepository
    {
        bool AddPhone(PersonInfoModel model);

        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        PersonInfoModel[] ListEntries(int startIndex, int count);
    }
}