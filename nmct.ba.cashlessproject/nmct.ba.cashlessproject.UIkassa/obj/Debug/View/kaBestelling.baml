   M S B A M L   `   `   `  ����Z  Vnmct.ba.cashlessproject.UIkassa, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:nmct.ba.cashlessproject.UIkassa.ViewModel)nmct.ba.cashlessproject.UIkassa.ViewModel  5      f bGalaSoft.MvvmLight.Platform, Version=5.0.2.32241, Culture=neutral, PublicKeyToken=5f873c45e98af8a1lMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.PlatformGalaSoft.MvvmLight.Command 5      e7clr-namespace:nmct.ba.cashlessproject.UIkassa.Converter)nmct.ba.cashlessproject.UIkassa.Converter  5      7    1nmct.ba.cashlessproject.UIkassa.View.kaBestelling   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Fvm7clr-namespace:nmct.ba.cashlessproject.UIkassa.ViewModel     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      WcmdMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Platform  5      ?c7clr-namespace:nmct.ba.cashlessproject.UIkassa.Converter  5      :d2http://schemas.microsoft.com/expression/blend/2008  5	      -   5          � 	Resources  5      F   @nmct.ba.cashlessproject.UIkassa.Converter.StringToImageConverter   StringToImageConverter  PanelTemplate  ProductsTemplate  BorderStyle  TextBlockBestellingStyle��%�   &	        &	      &	 ;     7  7    5   
   6#   �� 5   
   .R�5      � 5      �� 5   
   .R�5      �� 8��  ._�5      �� 8�� ��6   �� *ProductName+69   5      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��240 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5       $��* �6   �� 5!      $	��125 �6   �� 5"      $	��125 �6   �� 5#      $	��125 �6   �� 5$      $	��125 �6   �� 5%      $	��125 �6    � RowDefinitions 5'   
   �� 5(      $��80 �6   �� 5)      $	��170 �6   �� 5*      $��70 �6   �� 5+      $��* �6   �� 5,      $��70 �6   �� 5-      $��70 �6   .+�5/   
   �� -   5         ��Name$ 
btnLeesEID��5/        ButtonStyle#��[ 6%   $��Lees Klantenkaart��6m   $��10,10,50,10q�6�   ��6J   �� *LoadEidCommand+6�   � 50   
   -   5         �Name$ grdKlant��50      $��1��6!   $��3��6.    51      �� 52      $	��160 �6#   �� 53      $��* �6#    55      �� 56      $��* �6    �� 57      $��* �6    �� 58      $��* �6    �� 59      $��* �6    .+�5;      �� -   5         ��Name$ imgKlant��5;      $��4��6&     
ImageStyle#��[ 67   ��6[   �� *Klant.Picture+ �� 	Converter# [  �� 5<      -   5         ��Name$ lblNaam��5<      $��1��6%     LabelStyleTotaalLinks#��[ 65   $��Naam:��6d   �� 5=      -   5         ��Name$ txbNaam��5=   <   $��1��6M     TextBlockDetailStyle#��[ 6]   $��	96,5,7,10q�6�   ��6   �� *Klant.CustomerName+6�   �� 5>      -   5        $ 	lblBalans��5>      $��1��6'   $��1��67   #��[ 6E   $��10,0,0,1q�6t   .��6�   	Balans:6�   �� 5?      -   5        $ txbSaldo��5?   7   $��1��6I   $��1��6Y   #��[ 6f   $��
96,6,15,10q�6�   ��6   �� *Klant.Balance+6�   5@      �� 5A   
   -	   5        $ txbBestelling��5A      $��
Bestelling��6+   $��2��6=    	 TextBlockTitleStyle#��[	 6J   $��	10,0,24,0q�6w   �� 5B   
   -
   5        	 ��Name$	 lstBestelling��5B      $��3��6n   $��2��6{   $��3��6�    
 ListboxStyleLinks#��[
 6�   ��6*   �� *Sales+
 �� SelectedItem
 6H   �� *SelectedSale+ �� View 5C      �� 5D      -   5        grdBestelling��.P�5E      �� $��Product��6%    ! ListGridViewColumnHeaderStyle �� HeaderContainerStyle# [ 6h    �� DisplayMemberBinding 66   ��  �� Path$ ProductName�6h   �� 5F      $��Aantal��6%   # [ 6b    65   �� $ Amount�6b   �� 5G      $��Prijs��6%   # [ 6`    64   �� $ Price�6`   �� 5H      $��Totaal��6%   # [ 6f    65   �� $ 
TotalPrice�6f   5I      5K      �� 5L   
   -   5        $ btnVerwijderen��5L      $��5��6)   #��[ 66   ��6[   �� *VerwijderUitLijstCommand+.��6�   Verwijderen6�   �� 5M   
   $��5��6   $��1��6     LabelStyleTotaal#��[ 6-   $��Totaal in euro:��6W   $��2��6q   $��
0,14,34,14q�6�   $	��166��6�   �� 5N   
   $��5��6   $��2��6!     TextBlockStyleTotaal#��[ 6I   $��2��6w   $��79,22,10,22q�6�   $	��111��6�   ��61   �� *Totaal+6�   �� 5O   
   -   5         ��Name$ icProducten��5O   H   $��Disabled=�6     ListboxStyleRechts#��[ 6]   $��4��6�   $��4��6�   $��7��6�   #��[ 6  #��[ 64  
 6�   �� *SelectedProduct+��6�   �� *
Products+5P      �� 5Q   
   -   5         ��Name$ 
txtProduct��5Q      $��4��6S   $��4��6`   $��2��6p     TextboxStyle#��[ 6�   ��6&   �� *SelectedProduct.ProductName+6�   �� 5R   
   $��4��6   $��6��6   #��[ 6-   .��6W   	Aantal:6`   �� 5S   
   -   5        $ 	txtAantal��5S      $��4��6%   $��7��62   #��[ 6B   ��6h   �� *Aantal+�� 5T   
   -   5        $ btnPlus��5T      $��4��6"   $��8��6/   #��[ 6?   ��6d   �� *VerhoogAantalCommand+.��6�   +6�   �� 5U   
   -   5        $ btnMin��5U      $��4��6!   $��9��6.   #��[ 6>   ��6c   �� *VerminderAantalCommand+.��6�   -6�   �� 5V   
   -   5        $ btnToevoegen��5V      $��5��6'   $��6��64   $��2��6D   #��[ 6X   ��6}   �� *VoegToeAanBestellingCommand+.��6�   	Toevoegen6�   �� 5W   
   -   5        $ btnAfrekenen��5W      $��5��6'   $��8��64   $��2��6D   #��[ 6X   ��6}   �� *InsertIntoDBCommand+.��6�   	Afrekenen6�   5X      5Y      