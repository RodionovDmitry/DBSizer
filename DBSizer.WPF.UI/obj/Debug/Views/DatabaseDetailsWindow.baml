   M S B A M L   `   `   `  ����l  hSystem.Windows.Controls.DataVisualization.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting  5   	   G CDBSizer.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:DBSizer.Data;assembly=DBSizer.DataDBSizer.Data 5   	   X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit 5   	   I EDBSizer.WPF.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:DBSizer.WPF.UI.ViewModelsDBSizer.WPF.UI.ViewModels 5   	   E'clr-namespace:DBSizer.WPF.UI.ConvertersDBSizer.WPF.UI.Converters 5   	   0   *DBSizer.WPF.UI.Views.DatabaseDetailsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   �charting{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	   Adata0clr-namespace:DBSizer.Data;assembly=DBSizer.Data     5   	   Ixc:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5   	   >
viewModels'clr-namespace:DBSizer.WPF.UI.ViewModels     5   	   >
converters'clr-namespace:DBSizer.WPF.UI.Converters     5   	   $	��600��5
   	   $	��600��5   	   $	��600��5   	   $	��600��5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title 5	   	   �� *WindowCaption+ � DataContext 5      8  2DBSizer.WPF.UI.ViewModels.DatabaseDetailsViewModel  5   
    � 	Resources 5      6  0DBSizer.WPF.UI.Converters.EnumToBooleanConverter   
EnumToBool?  9DBSizer.WPF.UI.Converters.CharacteristicToStringConverter  DataToString��%:   &	        &	        5   
   6,     5   
   65   5      .��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��80 �6   �� 5      $	��110 �6   �� 5       $	��110 �6   �� 5!      $	��110 �6   �� 5"      $��* �6   .+�5$   
   �� $��0��5%      $��5q�5&      ��5'      �� *	Refresh+.��5(      �� $��Stretch=�6    �� Orientation$ 
Horizontal=�68   .+�5)      �� $��2q�6   $��16��6#   $
��Left=�6.   $��..\Resources\refresh.png��6I   �� 5*      $��Refresh��6   5+      5,      	� 5-   
   $��0��5.      $��1��5/       	� 	GroupName$ 0��53      $��Center=�54      $��5q�55       d� 	IsChecked 50      �� *CharacteristicToDisplay+	 �� 	Converter#	 [  !  DBSizer.Data.Characteristic
   DataSize �� ConverterParameter# Z
 ��56      �� *CharacteristicToDisplay+#	 [ # Z
 	� 59   
   $��0��5:      $��2��5;      $ 1��5?      $��Center=�5@      $��5q�5A       5<      �� *CharacteristicToDisplay+#	 [     	IndexSize# Z ��5B      �� *CharacteristicToDisplay+#	 [ # Z 	� 5E   
   $��0��5F      $��3��5G      $ 2��5K      $��Center=�5L      $��5q�5M       5H      �� *CharacteristicToDisplay+#	 [     RowCount# Z ��5N      �� *CharacteristicToDisplay+#	 [ # Z � 5Q   
   $��4��6   6!   �� 5R   
   $��Center=�6   $��4��6+   $��Show biggest��6;   %  Xceed.Wpf.Toolkit.IntegerUpDown  5S   
   $��Center=�5T      $
��Left=�5U      $��4��5V      $��80,0,0,0q�5X      �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 5W      �� *	NumValues+5X      �� 5Z   
   $��Center=�6   $
��Left=�6+   $��4��6F   $��values��6V   $��	120,0,0,0q�6g   >   8System.Windows.Controls.DataVisualization.Charting.Chart  5[   
     CommonChartStyle#��[ 5\      $��1��5]      $��5��5^         Series. 5_      L   FSystem.Windows.Controls.DataVisualization.Charting.StackedColumnSeries  I	   CSystem.Windows.Controls.DataVisualization.Charting.DefinitionSeries 	  SeriesDefinitions. 5`      I
   CSystem.Windows.Controls.DataVisualization.Charting.SeriesDefinition
   
  IndependentValuePath$ 	TableName��5c       
  DependentValuePath$ Value��5d        DataPointStyleA 
  DataPointStyle# [ 5e       
  Title 5a      �� *CharacteristicToDisplay+#	 [  
  ItemsSource 5b      �� *ItemsToShow+5e       	  IndependentAxis 5f      E   ?System.Windows.Controls.DataVisualization.Charting.CategoryAxis  5g      =   7System.Windows.Controls.DataVisualization.Charting.Axis   Orientation$ X=�5h      D   >System.Windows.Controls.DataVisualization.Charting.DisplayAxis   AxisLabelStyle 5i      �� 5j       �� 
TargetTypeB   <System.Windows.Controls.DataVisualization.Charting.AxisLabel"  6$   .�5k   "   ��  �� Property � �� �� Value 5l   &   �� 5m   *    �� 
TargetType"  6:   .R�5n   .   �� $��5q�68      FormattedContent#��z 6C    � LayoutTransform 5o   2   �� 5p   6    �� Angle$	 -90Q�6F   5r   /   5s   +   5u   #   5v      5x      5z      5{      � 5|   
   $��2��5}      $��5��5~      $��24��5      $��5q�5�      y�5�      �� *ProgressVisible+  	BoolToVis#	 [   � Value  5�      �� *ProgressValue+! �� Mode$! OneWay=�5�      5�      