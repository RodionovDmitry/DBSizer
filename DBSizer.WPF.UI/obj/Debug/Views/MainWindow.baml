   M S B A M L   `   `   `  ����l  hSystem.Windows.Controls.DataVisualization.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting  5   	   I EDBSizer.WPF.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:DBSizer.WPF.UI.ViewModelsDBSizer.WPF.UI.ViewModels 5   	   ;"clr-namespace:DBSizer.WPF.UI.ViewsDBSizer.WPF.UI.Views 5   	   %   DBSizer.WPF.UI.Views.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   �charting{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	   >
viewModels'clr-namespace:DBSizer.WPF.UI.ViewModels     5   	   4views"clr-namespace:DBSizer.WPF.UI.Views     5   	     � Title$   DBSizer by Rodionov Dmitry��5   	    � WindowStartupLocation$ CenterScreen=�5	      $	��540��5
      $	��700��5      $	��400��5      $	��300��5       � DataContext 5      -  'DBSizer.WPF.UI.ViewModels.MainViewModel  5   
   .��5      ]� .+�5   
   o� $	��Top=�6   .@�5      m� $
��Help��6   .@�5      m� $��About...��6    m� Command 6-   �� *ShowAboutWindow+6S   5      5      � 5       � ColumnDefinitions 5   
   �� 5      $	��295 �6   $	��295��6+   �� 5      $
��295* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��30 �6   �� 5      $��* �6   �� 5       $��30 �6   .+�5"   
   7  1DBSizer.WPF.UI.Views.SqlConnectionSettingsControl  -   5          Name$ SqlSettings��5#      $	��Top=�5$      $
��Left=�5%      $	��296��5'      $��0q�5(      $��	0,0,-10,0q�5)      $
��Left=�5*       5&      �� * SqlConnectionSettingsViewModel+5*      �� 5+   
   $��1��6   $
��Left=�6   $��0,3,0,0q�6U   ��68   �� *
HelpText+6U   �� 5,   
   $��1��6   $��Connect��6:   $
��Left=�6L   $��	215,5,0,0q�6g   $	��Top=�6z   $��75��6�   $��22��6�    J� RenderTransformOrigin$ 	0.4,0.545&�6�   $��1q�6�   ��6   �� *	Connect+6�   �� 5-   
   -   5        $��ListOfAllDatabases��5-      $��2��6,   $��0q�6^   ��69   �� *AllDataBases+��5.      �� 5/      .R�50      ��  �� Orientation$ 
Horizontal=�6!   .+�51      �� $��1q�6#   	 d� 	IsChecked	 6.   �� *	IsChecked+�� 52      $��5,0,0,0q�6$   ��65   �� *DisplayName+53      54      56      �� 57   
   $��3��6   $��3q�58      $
��Left=�59      $	��286��5:      $-��'Click here to analyze selected database��5;   -   ��6   �� *	Analyse+6-   �� 5<   
   $��1��6   $��4��6'   $
��Left=�68   $��4,0,0,0q�6S   $��7��6d   $ 0.5,0.5&�6n   �� 5=   
   $��1��6   $��4��6'   $��14,0,0,0q�69   $
��Auto=�6K   $��Hidden=�6p   .��5>      >   8System.Windows.Controls.DataVisualization.Charting.Chart     CommonChartStyle#��[  6   $
��Left=�6G   ��6b   �� *
ChartWidth+
   Series.
 5?      L   FSystem.Windows.Controls.DataVisualization.Charting.StackedColumnSeries  I   CSystem.Windows.Controls.DataVisualization.Charting.DefinitionSeries   SeriesDefinitions. 5@      I   CSystem.Windows.Controls.DataVisualization.Charting.SeriesDefinition     Title$ Data Size (MB)��5A         IndependentValuePath$ 	ShortName��5C         DependentValuePath$ DataSize��5D        DataPointStyleA   DataPointStyle# [ 5E         ItemsSource 5B      �� *DataBasesForChart+5E        5F      $ Log Size (MB)��5G      $ 	ShortName��5I      $ LogSize��5J        DataPointStyleB# [ 5K       5H      �� *DataBasesForChart+5K         IndependentAxis 5L      E   ?System.Windows.Controls.DataVisualization.Charting.CategoryAxis  5M      =   7System.Windows.Controls.DataVisualization.Charting.Axis   Orientation$ X=�60   D	   >System.Windows.Controls.DataVisualization.Charting.DisplayAxis 	  AxisLabelStyle 5N      �� 5O   "    �� 
TargetTypeB
   <System.Windows.Controls.DataVisualization.Charting.AxisLabel" 
 6(   .�5P   &   ��  �� Property � �� �� Value 5Q   *   �� 5R   .    �� 
TargetType" 
 6>   .R�5S   2   �� $��5q�6<    
  FormattedContent#��z 6G    � LayoutTransform 5T   6   �� 5U   :    �� Angle$	 -90Q�6J   5W   3   5X   /   5Z   '   5[   #   5]      5_      5`      5a      5b      5c      5d      