   M S B A M L   `   `   `  ����C  ?Lab3Mvvm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Lab3MvvmLab3Mvvm  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	       Lab3Mvvm.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Lab3Mvvm     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5
      � 
������� � DataContext 6   �� *MainViewModel+   Locator �� Source# [  .+�5   
   �� -   5         ��Name$ button��5      $	��Add��6!   $
��Left=�6N   $	��Top=�6i   $��75��6�   $��655,134,0,0q�6�   ��6/   �� *
AddCommand+6�   �� 5   
   -   5         ��Name$ listBox��5       �� DisplayMemberPath$ GetDisplayText��6o   $��0��6�   $��Center=�6�   $��Center=�6�   $	��221��6�   $	��498��6�   $��37,134,258.6,65q�6�   ��6#   �� *
MemberList+ �� SelectedItem 6F   �� *SelectedMember+6�   �� 5   
   $
��Left=�6   $��
37,101,0,0q�6/   $
��Wrap=�6C   $��
Customers:��6W   $	��Top=�6i   $��13��6�   $��91��6�   �� 5   
   $��Delete��6   $
��Left=�6D   $��655,200,0,0q�6_   $	��Top=�6t   $��75��6�   ��6"   �� *DeleteCommand+6�   �� 5   
   $
��Exit��6   $
��Left=�6    $��655,258,0,0q�6;   $	��Top=�6P   $��75��6h   ��6s   �� *ExitCommand+.  (System.Windows.Interactivity.Interaction   Triggers 5   
   /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ MouseRightButtonUp��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6(   �� *UpdateCommand+5      5      5      