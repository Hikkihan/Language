   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5          WpfApp1.DataList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp1     5        N� Title$  DataList��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��5* �6   .+�5   
   �� .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      ��  �� TextAlignment$ Right=�6   .+�5      �� Фильтр по полу:5      �� 5      $
��0,10q�6    Сортировка по:5      �� 5      Поиск:5      5      �� 5!      .+�5"      �� -   5        $��	genderBox��5"      $	��100��6N   ��5#      �� 5$      .R�5%   "   �� ��6,   ��  �� Path$
 Name�5&      5(      �� 5*      -   5        $��sortBox��5*   G   $	��0,3q�6:   $	��100��6V   .@�5+      �� .��6'   Фамилии50      51      �� 52      -   5        $��	searchBox��52      $	��100��6Q   .��6]   54      55      56      �� 58      .+�59      �� -   5        $	��210��59      $��30��6%   $
��Left=�6C   $
��0,10q�6^   .��6l   !Добавить клиента5;      �� 5=      -   5        $	��210��5=      $��30��6%   $
��Left=�6D   $
��0,10q�6_   .��6m   @>Редактировать выбранного клиента5?      5@      5A      �� 5E   
   $��1��6   .+�5F      &   System.Windows.Controls.DataGrid  -   5        $��dataGrid��5F   ^   $	��900��6   $	��300��6#   $��Bottom=�61      
IsReadOnly .    AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .  	   CanUserReorderColumns	 .  
   Columns
 5G      0  *System.Windows.Controls.DataGridTextColumn  5H      ,  &System.Windows.Controls.DataGridColumn   Header$ Фамилия��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� $ LastName�  5I      $ Имя��6)    66   �� $ 	FirstName�  5J      $ Отчество��6)    6;   �� $ 
Patronymic�  5K      $ Дата рождения��6)    6@   �� $ Birthday�  5L      $% Дата регистрации��6)    6C   �� $ RegistrationDate�  5M      $ Email��6)    68   �� $ Email�  5N      $ Телефон��6)    6:   �� $ Phone�  5O      $ Пол��6)    66   �� $ 
GenderCode�5Q      5R      5S      5T      