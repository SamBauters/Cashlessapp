   M S B A M L   `   `   `  ����Z  Vnmct.ba.cashlessproject.UIklant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:nmct.ba.cashlessproject.UIklant.ViewModel)nmct.ba.cashlessproject.UIklant.ViewModel  5      e7clr-namespace:nmct.ba.cashlessproject.UIklant.Converter)nmct.ba.cashlessproject.UIklant.Converter  5      <    6nmct.ba.cashlessproject.UIklant.View.kRegistrerenLogin   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Fvm7clr-namespace:nmct.ba.cashlessproject.UIklant.ViewModel     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ec7clr-namespace:nmct.ba.cashlessproject.UIklant.Converter     5      -   5          � DataContext  5
      C  =nmct.ba.cashlessproject.UIklant.ViewModel.kRegistrerenLoginVM  5   
    � 	Resources 5      F   @nmct.ba.cashlessproject.UIklant.Converter.StringToImageConverter   StringToImageConverter��%   &	          5   
   6#   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��180 �6   �� 5      $	��180 �6   �� 5      $	��180 �6   �� 5      $	��180 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��80 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5       $��* �6   �� 5!      $��80 �6   .+�5#   
   �� -   5         ��Name$ txbLogin��5#      $��0��6&   $��2��63   $��LOG IN MET JE E-ID��6C   $��122,30,70,27q�6]   $��2��6s     TextBlockStyle#��[ 6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��23��6�   �� 5$   
   -   5        $ txbInfo��5$      $��1��6%   $��4��62   $��1��6F   #��[ 6V   $J��DWanneer je nog geen account hebt wordt deze onmiddelijk aangemaakt. ��6~   $��
0,34,10,10q�6�   $��36��6�   �� 5%   
   -   5         ��Name$ imgIdentiteitskaart��5%      $��3��6-   $��2��6>   $��4��6K     
ImageStyle#��[ 6[   $��10,5,0,5q�6   ��6�   �� *Klant.Picture+ �� 	Converter# [  �� 5&   
   -   5        $ txbVoornaam��5&      $��2��6)   $��1��66   #��[ 6F   $��	0,21,0,20q�6n   	Voornaam:6�   �� 5'   
   -   5         ��Name$ txtVoornaam��5'      $��2��6'   $��2��64   $��2��6D   $��25��6r   $��	0,18,0,17q�6~   ��6X   �� *
Voornaam+6~   �� 5(   
   -   5        $ txbNaam��5(      $��3��6%   $��1��62   #��[ 6B   $��	0,21,0,20q�6j   Naam:6�   �� 5)   
   -   5        $ txtNaam��5)      $��3��6#   $��2��60   $��2��6@   $��25��6j   $��	0,18,0,17q�6v   ��6T   �� *Naam+6v   �� 5*   
   -	   5        $ 	txbStraat��5*      $��4��6'   $��1��64   #��[ 6D   $��	0,21,0,20q�6l   	Straat:6�   �� 5+   
   -
   5        $ 	txtStraat��5+      $��4��6%   $��2��62   $��2��6B   $��25��6m   $��	0,18,0,17q�6y   ��6V   �� *Adres+6y   �� 5,   
   -   5        $ lblStad��5,      $��5��6%   $��1��62   #��[ 6B   $��	0,21,0,20q�6j   Stad:6�   �� 5-   
   -   5        $ txtStad��5-      $��5��6#   $��2��60   $��2��6@   $��25��6j   $��	0,18,0,17q�6v   ��6T   �� *Stad+6v   �� 5.   
   -   5        	 ��Name$	 btnLeesKaartRegistreren��5.      $��6��62   $��2��6?   $��10,10,10,139q�6r   $��Lees EID��6�   ��6O   �� *LoadEidCommand+6�   �� 5/   
   -   5        $	 btnInloggen��5/      $��6��6&   $��3��63   $��10,10,10,139q�6�   $��Inloggen��6�   ��6C   �� *LogInCommand+��6d   �� 
 �� ElementName$
 RegisterLogin��6�   50      51      