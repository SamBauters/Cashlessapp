   M S B A M L   `   `   `  ����_  [nmct.ba.cashlessproject.UImanagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullo<clr-namespace:nmct.ba.cashlessproject.UImanagement.ViewModel.nmct.ba.cashlessproject.UImanagement.ViewModel  5   	   e7clr-namespace:nmct.ba.cashlessproject.UImanagement.View)nmct.ba.cashlessproject.UImanagement.View  5   	   5    /nmct.ba.cashlessproject.UImanagement.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Kvm<clr-namespace:nmct.ba.cashlessproject.UImanagement.ViewModel     5   	   Ev7clr-namespace:nmct.ba.cashlessproject.UImanagement.View     5   	   $	��750��5   ,   $
��1200��69     � Title  6	   �� *CurrentPage.Name+ � DataContext 5      B  <nmct.ba.cashlessproject.UImanagement.ViewModel.ApplicationVM  5   
    � 	Resources 5
       �� DataTypeA  ;nmct.ba.cashlessproject.UImanagement.ViewModel.mAanmeldenVM:   4nmct.ba.cashlessproject.UImanagement.View.mAanmelden=  7nmct.ba.cashlessproject.UImanagement.ViewModel.mKassaVM6   0nmct.ba.cashlessproject.UImanagement.View.mKassa>  8nmct.ba.cashlessproject.UImanagement.ViewModel.PageOneVM7   1nmct.ba.cashlessproject.UImanagement.View.PageOne?  9nmct.ba.cashlessproject.UImanagement.ViewModel.mKlantenVM8	   2nmct.ba.cashlessproject.UImanagement.View.mKlantenC
  =nmct.ba.cashlessproject.UImanagement.ViewModel.mMedewerkersVM<   6nmct.ba.cashlessproject.UImanagement.View.mMedewerkers?  9nmct.ba.cashlessproject.UImanagement.ViewModel.mProductVM8   2nmct.ba.cashlessproject.UImanagement.View.mProductD  >nmct.ba.cashlessproject.UImanagement.ViewModel.mStatistiekenVM=   7nmct.ba.cashlessproject.UImanagement.View.mStatistieken?  9nmct.ba.cashlessproject.UImanagement.ViewModel.mAccountVM8   2nmct.ba.cashlessproject.UImanagement.View.mAccount��%X  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)(�� �     5      *,
 +)(�� �     5      *, +)(�� ,    5      *, +)(�� ^    5       *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5      	  5      �� 5   
   " 
 6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5    
   "  6   .R�5!        5"      5#      .��5$      �  � ColumnDefinitions 5%   
   �� 5&      $
��212* �6   �� 5'      $	��47* �6    � RowDefinitions 5*   
   �� 5+      $��50 �6   �� 5,      $��2* �6   .+�5.   
   �� ���#F2F2F2$
��Left=�6#   $	��719��6>   $	��Top=�6K   $
��1192��6c   $��2��6p   $��2��6�   �� 5/   
   -   5        $��btnAfmelden��5/   6      HeaderStyle#��[  6   $��Afmelden��6I   $��0��6\   $��1��6i   ��6y   �� *AfmeldenCMD+�� 51   
   $��0��65   $��0��6E   $��2��6R   $��0,0,0,0q�6f   ��6   �� *Pages+��52      �� 53      .R�54      �� #��[  6   ��6C   �� *Name+��6\   �� *DataContext.ChangePageCommand+ �� RelativeSource ��  �� AncestorType" ���6�   �� 55      ��57      �� 58      .R�59      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�6:   5:      5<      �� 5>   
   $��1��6   $��2��6F   $��0,0,0,0q�6Z   ��6&   �� *CurrentPage+6Z   5?      5@      