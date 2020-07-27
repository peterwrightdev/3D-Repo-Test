# 3D-Repo-Test

Project created for 3D Repo technical test.

General description of solution and approach taken;

Solution implements an MVVM approach to meet requirements of the three tasks laid out in instructions provided by 3D-Repo.

View is set out in View\MainWindow.xaml/.cs, which utilses ViewModels of ViewModel\IssueViewModel and ViewModel\RiskViewModel in order to retrieve data from 3D-Repo APIs via the client supplied for Views and Risk respectively.
This separation into two separate viewmodels is used to resolve task 3, where radioList RadioButton controls are used to dynamically load in which ViewModel is used to populate the form, allowing the user to switch between Views and Risks.

The view utilizes several MultiValueConverters in order to convert values from the underlying objects received from 3D-Repo to populate their respective UI elements.
For example the StatusToIconConverter receives the status/mitigation_status of the underlying item and returns the appropriate unicode value.
Converters that have functionality which differ depending on whether the underlying object is an Issue or a Risk determine which type of conversion to run based on the types of inputs received.



Known issues/points of improvement not implemented yet;

Filter function pulls fresh set of data back from 3D-Repo API every time it is called. Assuming that the data does not change that frequently, it would be better to maintain a local copy of the last set of data received from 3D-Repo and just manipulate a list for UI rendering.

Noticed that the icon colour manipulation is slightly off. Correct colour is applied according to specification, but icon colours seem inverted. A slightly different colour manipulation should be applied (currently updates Foreground).

No unit tests in solution. Did not have time to implement. Would inject instances of interfaces as mocks in test project to verify behaviour.

ColorMapping approach may not be optimal for extension. Seemed there were various cases the same colours would be applied - While ColorMapping static dictionary is used to store these mappings it's a very bare-bones approach.

Converters use the types of input values to determine logic to execute. This enforces that the UI must supply values in a specific order and could become problematic as more views and data types are added. A rework of the approach in the converter could be taken to identify mapping to apply more generically.
