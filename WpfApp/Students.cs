using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace WpfApp;

internal class Students : IComparable<Students>
{
    public Students(int id, string name, Gender gender)
    {
        StudentId = id;
        Name = name;
        Gender = gender;
    }
    public int StudentId { get; set; }
    public string Name { get; set; }

    public Gender Gender { get; set; }

    public int CompareTo(Students other)
    {
        return StudentId.CompareTo(other.StudentId);
    }
}