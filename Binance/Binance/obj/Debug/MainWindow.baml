   M S B A M L   `   `   `  ����  Binance    Binance.MainWindow   5   	   a ]DevExpress.Xpf.Core.v19.2, Version=19.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _DevExpress.Xpf.Charts.v19.2, Version=19.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxc4http://schemas.devexpress.com/winfx/2008/xaml/charts  5   	   X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   $
��1900��5
   	     � Title$  Binance��5   	    � WindowState$ 	Maximized=�5      $
��1080��5   	   
������  � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5      �� 5      $
��277* �6   �� 5      $��1296* �6    �� 5      $
��400* �6   .+�5   
   �� $��3��6   ��5      �� 5      .��5      �  � Color$ #353839��6#    � Offset$ 0Q�63   � 5      $ #353839��6#   $	 0.7Q�63   5      ._�5!      �� -   5         ��Name$ button��5!      $��1M��5#      $
��Left=�5%      $��52��5&      $��
829,43,0,0q�5'      $	��Top=�5(      $��80��6-   ��5$      �� *load5+5(   -   5E      �� 5G   
   -   5         ��Name$ ListViewSymbols��5G      ���#3b444b
������ $��0,4,0,6q�5K      $��Tahoma)�5N      $��16(�5O      
�������$
��Left=�5Q      $	��269��5R      ��5L      �� *
Everything+ �� SelectedItem 5M      �� *SelectedSymbol+	 �� View	 5T      �� 5U      .P�5V      �� 
 �� Width$	
 130��5W   '   $��Ad��5X   *    �� DisplayMemberBinding 5Y   *   �� *Symbol+�� 5Z      $	
 130��6&   $��Fiyat��5[   *    5\   *   �� *Price+5]      5_      ]� 5g   
   $��1��6   $��1��6!   .+�5h      (  "DevExpress.Xpf.Charts.ChartControl  -   5          Name$ chartControl1��5h      
������ $
��Left=�5j      
������ 
�������$��28,78,24,396q�5m      $��Center=�5n       J� RenderTransformOrigin$ 0.5,0.5&�5o      $��1��5p      $
��1224��5q         Diagram. 5r      '  !DevExpress.Xpf.Charts.XYDiagram2D  -   5          Name$ chartDiagram��5r   #   
������    EnableAxisXNavigation .    DefaultPane 5t         DevExpress.Xpf.Charts.Pane  5u         DomainBrush �#3538396#      AxisX 5x      #  DevExpress.Xpf.Charts.AxisX2D  5y      $  DevExpress.Xpf.Charts.AxisBase   Label 5z      %  DevExpress.Xpf.Charts.AxisLabel  5{   "      TextPattern$ 	{A:HH:mm}��60   
�������5|   0      DateTimeScaleOptions 5~      6  0DevExpress.Xpf.Charts.ManualDateTimeScaleOptions  5   "      AutoGrid .     GridAlignment$
 Hour=�5�   =      MeasureUnit$ Minute=�5�   =   5�         AxisY 5�      #  DevExpress.Xpf.Charts.AxisY2D  5�       5�        5�   "   $��Verdana)�60   $��Italic$�5�   0   
�������5�   0    	  DevExpress.Xpf.Charts.Axis 	  
WholeRange 5�      !
  DevExpress.Xpf.Charts.Range
  5�   "      AlwaysShowZeroLevel .  6,   5�      #  DevExpress.Xpf.Charts.Diagram   Series. 5�      )  #DevExpress.Xpf.Charts.StockSeries2D  -   5          Name$ stockSeries��5�   $   "  DevExpress.Xpf.Charts.Series   
Background
 ���� $  DevExpress.Xpf.Charts.XYSeries    Brush$  Green��6:   !   ArgumentDataMember$! OpenTime��5�   $   -  'DevExpress.Xpf.Charts.FinancialSeries2D"   HighValueDataMember$
" High��5�   $   #   LowValueDataMember$	# Low��5�   $   $   OpenValueDataMember$
$ Open��5�   $   %   CloseValueDataMember$% Close��5�   $   &   AnimationAutoStartMode$& SetStartState=�5�   $   '   ArgumentScaleType$' DateTime=�5�   $   (   LabelsVisibility( . )   
DataSource) 5�   $   �� *SelectedSymbol.OneHour+&   DevExpress.Xpf.Charts.XYSeries2D*   
Indicators* 5�      /  )DevExpress.Xpf.Charts.SimpleMovingAverage  5�      )  #DevExpress.Xpf.Charts.MovingAverage+   PointsCount$+ 1��66   ,   
ValueLevel$
, High=�5�   2   -   ReductionOptions- 5�      1  +DevExpress.Xpf.Charts.ReductionStockOptions  5�      .   Level$. 	HighValue=�68   /   	ColorMode$/ OpenToCloseValue=�5�   4   0   Model0 5�      ,  &DevExpress.Xpf.Charts.FlatStock2DModel  5�      5�      1  +DevExpress.Xpf.Charts.BarSideBySideSeries2D  5�      5�      5�      5�      �� 5�   
   -   5        1 ��Name$1 txtblock��5�      2 �� Padding$2 
10 10 10 0q�5�      $��
74,9,0,948q�5�      $
��Left=�5�      3 �� TextAlignment$
3 Left=�5�      
������ 
�������$��30(�5�      $��Verdana)�5�      $	��482��5�      $��1��6!   �� 62   $
��Bold"�66   �5�   &   �� *SelectedSymbol.Symbol+ �� 5�      $� ��6    �� 5�      $
��Bold"�6   �5�      �� *SelectedSymbol.Price+5�      �� 5�   
   -   5        $ listviewTradeHistory��5�      $��Right=�5�      
������ 
������ $	��400��5�      $��Tahoma)�5�      
�������$��1��5�      $��0,235,-2,359q�5�      $��2��5�      ��5�      �� *SelectedSymbol.TradeHistory+	 5�      �� 5�      .P�5�      �� $	
 130��5�   *   $��İşlem Geçmişi��5�   *    5�   *   �� *Price+�� 5�      $	
 160��6&   $��Tarih��5�   *    5�   *   �� *Time+�� 5�      $	
 100��6%   $��ID��5�   %    5�   %   �� *Id+5�      5�      �� 5�   
   $��
2,14,0,839q�5�      $��Verdana)�5�      $��20(�5�      
���   �
������ ���	#FFFFAE00$��2��5      $
��Left=�5     $	��376��5     ��5     �� 5     -   5        4 ��Name$4 lbl24��5     $��24 saatlik istatistikler��5     
�������
������ 5     .��5	     �� $��
0,0,-14,-7q�6   $	��144��5
     $��Bottom=�5     .+�5     � $��34��6   $��0,0,10,0q�5     .+�5     �� -	   5        $1 
txtBlock24��5      $
��Left=�5     $
3 Left=�5     $��Verdana)�5     $��18(�5     $��0,0,0,1q�5     
�������$	��176��5     $��24 saatlik değişim��5     �� 5     -
   5        $1 txtBlockYüzde��5      $
��Left=�5     $��Stretch=�5     $
3 Left=�5     $��Verdana)�5     $��18(�5     $��
181,-1,0,1q�5     $ 0.5,0.5&�5     $	��110��5      
���������5     �� *$"SelectedSymbol.PriceChangedPercent+5!     5"     � 5#     $��33��6   $��0,0,10,0q�6#    5$     �� 5%     $	��19* �6+   �� 5&     $��7* �6+   .+�5)     �� -   5        $1 txtBlockenyuksek��5)      $
��Left=�5*      $
3 Left=�5+      $��Verdana)�5,      $��18(�5-      
�������$	��152��5/      $��En Yüksek Fiyat��50      �� 51     -   5        $1 txtBlockEnYuksek��51      $
��Left=�52      $��Stretch=�53      $
3 Left=�54      $��Verdana)�56      $��18(�57      $��
181,-1,0,1q�58      $ 0.5,0.5&�59      $	��110��5:      
�������$��2��5<      ��55      �� *SelectedSymbol.HighPrice+5<      5=     � 5>     $��34��6   $��0,0,10,0q�6#   .+�5?     �� -   5        $1 txtBlockendusuk��5?      $
��Left=�5@      $
3 Left=�5A      $��Verdana)�5B      $��18(�5C      
�������$	��147��5E      $��En Düşük Fiyat��5F      �� 5G     -   5        $1 txtBlockEnDusuk��5G      $
��Left=�5H      $
3 Left=�5I      $��Verdana)�5K      $��18(�5L      $��	182,0,0,0q�5M      $	��110��5N      
���������5J      �� *SelectedSymbol.LowPrice+5O      5P     � 5Q     $��32��6   $��0,0,10,0q�6#    5R     �� 5S     $	��25* �6+   �� 5T     $
��131* �6+   .+�5V     �� -   5        $1 txtBlockvolume��5V      $
��Left=�5W      $��Verdana)�5X      $��18(�5Y      $
3 Left=�5Z      $	��154��5[      
�������$��2��5]      $��Hacim��5^      �� 5_     -   5        $1 txtBlockVolume��5_      $
��Left=�5`      $��Stretch=�5a      $
3 Left=�5b      $��Verdana)�5d      $��18(�5e      $��	133,0,0,0q�5f      $	��110��5g      
�������$��1��5i      ��5c      �� *SelectedSymbol.Volume+5i      5j     5k     5l     �� 5n  
   $��
0,814,32,0q�6   $	��150��5o     $	��326��5p     $��2��5q     $��Right=�5r     $	��Top=�5s     ��5t     �� 5u     $��Buy/Sell��6   $��20(�5v     
�������5w     .��5z     �� .+�5{     �  5|     �� 5}     �� 5~     .+�5�     �� $��Price��6    
�������5�      %  Xceed.Wpf.Toolkit.DecimalUpDown  5�     $��5q�6*   $��1��5�  *   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]5   Value5 5�  *   �� *SelectedSymbol.Price+5�  *   5�     � 5�      5�     �� 5�     �� 5�     .+�5�     �� $��Amount��6    
�������5�        5�     $��5q�6*   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]6   FormatString$6 F8��5�  *   $��1��5�  *   5 5�  *   �� *SelectedSymbol.TradeAmount+5�  *   5�     �� 5�     $	��150��6   7 �� Orientation$7 
Horizontal=�6)   .+�5�     �� $��60��6   $��5q�5�     $
��Sell��5�     ��5�     �� *SellCommand+5�     �� 5�     $��60��6   $��5q�5�     $	��Buy��5�     ��5�     �� *
BuyCommand+5�     5�     5�     5�     5�     5�     