# SuperCalculator

This is a Super Calculator app may be used as example Model-___View-ViewModel___ template.

So, let's figure it out:

This is a WPF Application, built in one Project in Solution. Project uses .NET of v7.0-windows, because WPF applications are unable to run on general version (v7.0).
The `-windows` specification signs that this program may run only on machines with OS Windows (This is WPF limitation).

Firstly, project contains 3 directories (modules) and two files in root. This two files required to run the WPF App and were generated automatically with project template.

Keep mind on this three modules:

## View
This module contains in general two files:
 - MainWindow.xaml
 - MainWindow.xaml.cs
 
 This is two files that contains one partial class named MainWindow. This class performs duties of View layer. The XAML file contains markup of the future window, which the user will see.
 Current XAML Markup contains initialization of DataContext that appears in the form of ViewModel, and than the Grid layout, that contains all of UI Elements for user interaction.
 The Grid consists of 5 row definitions and 4 column definition. Here is TextBox, that occupies 75% of the area of the first Grid Row, after which situated the Clear button.
 The entire area below is occupied by buttons with digits, comma, and basic arithmetic operations. To get the solution user should click the Equals button with symbol `=`.
 
Second file is MainWindow.xaml.cs contains only initialization of View components. 

## ViewModel
This module also contains two files. Here are:
 - ViewModel.cs
 - MainViewModel.cs
 
ViewModel is abstract class that implements interface INotifyPropertyChanged of standard system library. It passes only one event `PropertyChanged`, that being invoked when any property in this class changes theirs values.
Moveover, here is two more methods: protected OnPropertyChanged that simply invokes previously described event and protected SetField method, that should be used by inheritors of this class.
MainViewModel is concrete extension of ViewModel class for MainWindow, it contains one Property called `Value`, that updates own field value via super SetField method. Also here
described a lot of inline-get ICommand Properties. They are bound on Buttons in MainWindow and called theirs action in case of some button interacted. The Value property is bound to TextBox UI element of MainWindow,
and it instantly observes for updates of this property, being subscribed on previously described event `PropertyChanged`.

## Extra

In the module above, ICommand properties are initialized with special extra class called CommandDelegate. This class implements System `ICommand` interface and allows to store its object to call `execute` method in case, when it required
(eg. button clicked).

You can use this code for any purpose however, the author does not guarantee its performance and correct operation.
Licensed under the GNU General Public License v3.0
