using MySetProj;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    MySet<Students> _men = new MySet<Students>();
    MySet<Students> _women = new MySet<Students>();

    MySet<Students> _reading = new MySet<Students>();
    MySet<Students> _writing = new MySet<Students>();
    MySet<Students> _arithmetic = new MySet<Students>();

    Dictionary<string, MySet<Students>> allSets = new Dictionary<string, MySet<Students>>();

    public MainWindow()
    {
        Students james = new Students(id: 1, name: "James", Gender.Male);
        Students robert = new Students(id: 2, name: "Robert", Gender.Male);
        Students john = new Students(id: 3, name: "John", Gender.Male);
        Students mark = new Students(id: 4, name: "Mark", Gender.Male);
        Students otherMark = new Students(id: 5, name: "Mark", Gender.Male);
        _men.AddRange(new Students[] { james, robert, john, mark, otherMark });

        Students liz = new Students(id: 1, name: "Liza", Gender.Female);
        Students amy = new Students(id: 2, name: "Amy", Gender.Female);
        Students eve = new Students(id: 3, name: "Evelyn", Gender.Female);
        _women.AddRange(new Students[] { liz, amy, eve });

        _reading.AddRange(new Students[] { james, robert, liz });
        _writing.AddRange(new Students[] { robert, mark, amy, liz });
        _arithmetic.AddRange(new Students[] { john, mark, otherMark, amy });

        allSets.Add("Men", _men);
        allSets.Add("Women", _women);
        allSets.Add("Reading", _reading);
        allSets.Add("Writing", _writing);
        allSets.Add("Arithmetic", _arithmetic);

        InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        foreach (string name in allSets.Keys)
        {
            leftSet.Items.Add(name);
            rightSet.Items.Add(name);
        }
        operation.Items.Add("UNION");
        operation.Items.Add("INTERSECTION");
        operation.Items.Add("DIFFERENCE");
        operation.Items.Add("SYMETRIC DIFF");


    }

    private void leftMySet_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        leftMembers.Items.Clear();

        if (e.AddedItems.Count > 0)
        {
            DisplayMySetData(GetMySetByName(e.AddedItems[0].ToString()), leftMembers);
        }
    }

    private void rightMySet_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        rightMembers.Items.Clear();

        if (e.AddedItems.Count > 0)
        {
            DisplayMySetData(GetMySetByName(e.AddedItems[0].ToString()), rightMembers);
        }
    }

    private MySet<Students> GetMySetByName(string? name)
    {
        return allSets[name];
    }

    private void DisplayMySetData(MySet<Students> set, ListBox listBox)
    {
        foreach (var student in set)
        {
            listBox.Items.Add(student.Name);
        }
    }

    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var listBox = sender as ListBox;
        var selectedItem = listBox.SelectedItem;

        MessageBox.Show(selectedItem.ToString());
    }

    private void evaluateButton_Click(object sender, RoutedEventArgs e)
    {
        if (leftSet.SelectedItem == null || rightSet.SelectedItem == null || operation.SelectedItem == null)
        {
            MessageBox.Show("Please select both sets and operation!");
            return;
        }

        var left = GetMySetByName(leftSet.SelectedItem.ToString());
        var right = GetMySetByName(rightSet.SelectedItem.ToString());
        var op = operation.SelectedItem.ToString();

        MySet<Students> result = new MySet<Students>();

        switch (op)
        {
            case "UNION":
                result = left.Union(right);
                break;

            case "INTERSECTION":
                result = left.Intersection(right);
                break;

            case "DIFFERENCE":
                result = left.Difference(right);
                break;

            case "SYMETRIC DIFF":
                result = left.SymmetricDifference(right);
                break;
        }

        resultSet.Items.Clear();
        DisplayMySetData(result, resultSet);
    }
}
