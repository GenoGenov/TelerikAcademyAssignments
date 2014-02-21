using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public interface ICommentable
    {
        void AddComment(string comment);

        void RemoveComment(int index);

        void ClearComments();

        void PrintComments();
    }
}