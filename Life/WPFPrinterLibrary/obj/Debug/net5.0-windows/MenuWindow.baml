   M S B A M L   `   `   `  ����L  HWPFPrinterLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WPFPrinterLibraryWPFPrinterLibrary  5   	   "    WPFPrinterLibrary.MenuWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WPFPrinterLibrary     5   	     � Title$  Conway's Game of Life��5   	    � SizeToContent$ WidthAndHeight=�5	   	   .��5
      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   �� $��0��6   $��0��6"   $��3��62   $��10q�6F   .+�5      �� -   5        $��btnAddField233��5      $��10q�6+   $��5q�67   
�������
���   �.��6�   53Add Field (3 cells around to start, 2-3 to survive)6�   �� 5      -   5        $��btnAddField344��5      $��10q�6+   $��5q�67   
�������
���   �.��6�   53Add Field (4 cells around to start, 3-4 to survive)6�   �� 5      -   5        $��btnAddField234��5      $��10q�6+   $��5q�67   
�������
���   �.��6�   53Add Field (3 cells around to start, 2-4 to survive)6�   5      �� 5   
   $��1��6   $��0��6   $��10q�6-   $��Center=�69   .��6T   Generation #6b   �� 5   
   -   5        $��tbGeneration��5      $��1��6&   $��1��63   $��10q�6C   $	��100��6O   $��Center=�6^   6{   �� 5   
   -   5        $��btnGeneration��5      $��1��6&   $��2��63   $��10q�6C   $��5q�6O   
�������
���   �.��6�   Set this value as maximum6�   �� 5   
   $��2��6   $��0��6   $��10q�6-   $��Center=�69   .��6T   Sleep time (ms):6f   �� 5    
   -   5        $��tbSleepTime��5       $��2��6%   $��1��62   $��10q�6B   $	��100��6N   $��Center=�6]   6z   �� 5!   
   -   5        $��btnSleepTime��5!      $��2��6%   $��2��62   $��10q�6B   $��5q�6N   
�������
���   �.��6�   Save6�   �� 5"   
   -   5        $��btnPause��5"      $��3��6!   $��0��6.   $��3��6>   $��10q�6R   $��5q�6^   
�������
���   �.��6�   Pause6�   �� 5#   
   -	   5        $��btnRun��5#      $��4��6   $��0��6,   $��3��6<   $��10q�6P   $��5q�6\   
�������
���   �.��6�   Run6�   5$      5%      