   M S B A M L   `   `   `  ����_  [nmct.ba.cashlessproject.UImanagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullo<clr-namespace:nmct.ba.cashlessproject.UImanagement.ViewModel.nmct.ba.cashlessproject.UImanagement.ViewModel  5      8    2nmct.ba.cashlessproject.UImanagement.View.mAccount   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Kvm<clr-namespace:nmct.ba.cashlessproject.UImanagement.ViewModel     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � DataContext  5	      ?  9nmct.ba.cashlessproject.UImanagement.ViewModel.mAccountVM  5
   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��195 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��70 �6   �� 5      $��70 �6   �� 5      $��70 �6   �� 5      .+�5   
   �� $��1��6   $��Huidig paswoord:��6!      TextBlockStyle#��[  69   $��2��6a   $��10,26,158,25q�6u   �� 5   
   $��2��6   $��Nieuw paswoord:��6!   #��[  68   $��2��6`   $��10,26,158,25q�6t   �� 5   
   $��3��6   $��Bevestig paswoord:��6!   #��[  6;   $��2��6c   $��10,26,158,25q�6w   �� 5    
   -   5         ��Name$ txtHuidigPaswoord��5    b   $��1��61   $��1��6>   $��3��6N     TextBoxStyle#��[ 6}   $��
10,20,0,20q�6�   $	��326��6�   ��6   �� *OudWachtwoord+6�   �� 5!   
   -   5        $ txtNieuwPaswoord��5!   d   $��2��63   $��1��6@   $��3��6P   #��[ 6~   $��
10,20,0,20q�6�   $	��326��6�   ��6   �� *NieuwWachtwoord+6�   �� 5"   
   -   5        $ txtBevestigPaswoord��5"   g   $��3��66   $��1��6C   $��3��6S   #��[ 6�   $��
10,20,0,20q�6�   $	��326��6�   ��6   �� *BevestigWachtwoord+6�   �� 5#   
   -   5         ��Name$ btnWijzigPaswoord��5#   F   $��3��69     ButtonStyle#��[ 6a   $��
10,15,8,15q�6�   $��Wijzig paswoord��6�   $��3��6�   ��6   �� *SavePasswordCommand+6�   5$      5%      