   M S B A M L   `   `   `  ����B  >Notepad, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:NotepadNotepad  5   	   9!clr-namespace:Notepad.View_ModelsNotepad.View_Models  5   	   /clr-namespace:Notepad.ModelsNotepad.Models  5   	       Notepad.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Notepad     5   	   8
viewmodels!clr-namespace:Notepad.View_Models     5   	   /modelsclr-namespace:Notepad.Models     5   	     � Title$  	Notepad++��5
   	   $	��450��6   $	��800��6(    � Icon$2 ,pack://application:,,,/Icons/window_icon.png��5   	    � DataContext 5      '   !Notepad.View_Models.MainViewModel  5   
    J� InputBindings 5      �� 5   
   
 �� Key$ N��6    �� 	Modifiers$ Controlf�6    �� Command 61   �� *NewFileCommand+�� 5   
   $ O��6   $ Controlf�6    61   �� *OpenCommand+�� 5   
   $ S��6   $ Controlf�6    61   �� *SaveFileCommand+�� 5   
   $ D��6   $ Controlf�6    61   �� *SaveAsCommand+�� 5   
   $ E��6   $ Controlf�6    61   �� *ExitCommand+�� 5   
   $ F��6   $ Controlf�6    61   �� *FindCommand+�� 5   
   $ R��6   $ Controlf�6    61   �� *ReplaceCommand+�� 5   
   $ L��6   $ Controlf�6    61   �� *ReplaceAllCommand+�� 5   
   $ C��6   $ Controlf�6    61   �� *CopyCommand+�� 5   
   $ V��6   $ Controlf�6    61   �� *PasteCommand+�� 5   
   $ X��6   $ Controlf�6    61   �� *
CutCommand+�� 5    
   $ A��6   $ Controlf�6    61   �� *AboutCommand+.��5#      ]� $��1q�6   .+�5$   
   o� $��20��6   $	��Top=�6   
�������$	��799��6G   .@�5%      m� $
��File��6   $��20��6%   .@�5&      m� $	��New��6    m� InputGestureText$ Ctrl+N��6(    m� Command 6B   �� *NewFileCommand+	 m� Icon	 5'      �� 5(      $*��$pack://application:,,,/Icons/new.png��6    5*      m� 5+      $
��Open��6   $ Ctrl+O��6)    6C   �� *OpenCommand+	 5,      �� 5-      $+��%pack://application:,,,/Icons/open.png��6    5/      m� 50      $
��Save��6   $ Ctrl+S��6)    6C   �� *SaveFileCommand+	 51      �� 52      $+��%pack://application:,,,/Icons/save.png��6    54      m� 55      $��Save As��6   $ Ctrl+D��6,    6F   �� *SaveAsCommand+	 56      �� 57      $.��(pack://application:,,,/Icons/save_as.png��6    59      �� 5:      m� 5;      $
��Exit��6   $ Ctrl+E��6)    6C   �� *ExitCommand+	 5<      �� 5=      $+��%pack://application:,,,/Icons/exit.png��6    5?      5@      m� 5B      $��Search��6   .@�5C      m� $
��Find��6   $ Ctrl+F��6)    6C   �� *FindCommand+	 5D      �� 5E      $+��%pack://application:,,,/Icons/find.png��6    5G      m� 5H      $��Replace��6   $ Ctrl+R��6,    6F   �� *ReplaceCommand+	 5I      �� 5J      $.��(pack://application:,,,/Icons/replace.png��6    5L      m� 5M      $��Replace All��6   $ Ctrl+L��60    6J   �� *ReplaceAllCommand+	 5N      �� 5O      $2��,pack://application:,,,/Icons/replace_all.png��6    5Q      m� 5S      $��
Go to line��6    6/   �� *GoToLineCommand+	 5T      �� 5U      $+��%pack://application:,,,/Icons/goto.png��6    5W      5X      m� 5Z      $
��Edit��6   .@�5[      m� $
��Copy��6   $ Ctrl+C��6)    6D   �� *CopyCommand+
 m� CommandParameter
 5\      ��  �� ElementName$ 
tabControl�� �� Path$# SelectedItem.SelectedTextFile�	 5^      �� 5_      $+��%pack://application:,,,/Icons/copy.png��6    5a      m� 5c      $��Peste��6   $ Ctrl+V��6*    6D   �� *PasteCommand+
 5d      �� $ 
tabControl��$# SelectedItem.SelectedTextFile�	 5f      �� 5g      $,��&pack://application:,,,/Icons/paste.png��6    5i      m� 5k      $	��Cut��6   $ Ctrl+X��6(    6B   �� *
CutCommand+
 5l      �� $ 
tabControl��$# SelectedItem.SelectedTextFile�	 5n      �� 5o      $*��$pack://application:,,,/Icons/cut.png��6    5q      �� 5r      m� 5t      $��Convert Text to Lowercase��6    6>   �� *LowercaseCommand+
 5u      �� $ 
tabControl��$# SelectedItem.SelectedTextFile�	 5w      �� 5x      $0��*pack://application:,,,/Icons/lowercase.png��6    5z      m� 5|      $��Convert Text to Uppercase��6    6>   �� *UppercaseCommand+
 5}      �� $ 
tabControl��$# SelectedItem.SelectedTextFile�	 5      �� 5�      $0��*pack://application:,,,/Icons/uppercase.png��6    5�      �� 5�      m� 5�      $��Remove empty lines��6    67   �� *RemoveEmptyLinesCommand+
 5�      �� $ 
tabControl��$ SelectedItem.Text�	 5�      �� 5�      $9��3pack://application:,,,/Icons/remove_empty_lines.png��6    5�      m� 5�      $��	Read Only��6    m� IsCheckable .  6.   �� *ReadOnlyCommand+
 5�      �� $ 
tabControl��$ SelectedItem.IsReadonly�5�      5�      m� 5�      $
��Help��6   .@�5�      m� $��About��6   $ Ctrl+A��6*    6D   �� *AboutCommand+	 5�      �� 5�      $,��&pack://application:,,,/Icons/about.png��6    5�      5�      5�      � 5�   
   $	��Top=�6   $��22��6$   
�������$��0,0,0,0q�6G   $	��785��6X   .+�5�      �� -   5        $��NewFileButton��5�      $��20��6*   $
��Left=�65   ���	#FFDDDDDD � ToolTip$ New File��5�   -   ��5�   P   �� *NewFileCommand+.��5�      �� $*��$pack://application:,,,/Icons/new.png��6   5�      �� 5�      -   5        $��
OpenButton��5�      $��20��6'   $��20,0,0,0q�62   $
��Left=�6D   ���	#FFDDDDDD$
 Open��5�   -   ��5�   _   �� *OpenCommand+.��5�      �� $+��%pack://application:,,,/Icons/open.png��6   5�      �� 5�      -   5        $��
SaveButton��5�      $��20��6'   $��40,0,0,0q�62   $
��Left=�6D   ���	#FFDDDDDD$
 Save��5�   -   ��5�   _   �� *SaveFileCommand+.��5�      �� $+��%pack://application:,,,/Icons/save.png��6   5�      �� 5�      -   5        $��SaveAsButton��5�      $��20��6)   $��60,0,0,0q�64   $
��Left=�6F   ���	#FFDDDDDD$ Save As��5�   -   ��5�   a   �� *SaveAsCommand+.��5�      �� $.��(pack://application:,,,/Icons/save_as.png��6   5�      �� 5�      	 �� X1$ 0��6   	 �� X2$ 0��6   	 �� Y1$ 0��6"   	 �� Y2$ 20��6)   
���   �$	��0.5��6@   $��85,0,0,0q�6V   �� 5�      -   5        $��
FindButton��5�      $��20��6'   $��90,0,0,0q�62   $
��Left=�6D   ���	#FFDDDDDD$
 Find��5�   -   ��5�   _   �� *FindCommand+.��5�      �� $+��%pack://application:,,,/Icons/find.png��6   5�      �� 5�      -   5        $��ReplaceButton��5�      $��20��6*   $��	112,0,0,0q�65   $
��Left=�6H   ���	#FFDDDDDD$ Replace��5�   -   ��5�   c   �� *ReplaceCommand+.��5�      �� $.��(pack://application:,,,/Icons/replace.png��6   5�      �� 5�      -   5        $��ReplaceAllButton��5�      $��20��6-   $��	134,0,0,0q�68   $
��Left=�6K   ���	#FFDDDDDD$ Replace All��5�   -    J� RenderTransformOrigin$ 
1.17,0.584&�6C   ��5�   f   �� *ReplaceAllCommand+.��5�      �� $2��,pack://application:,,,/Icons/replace_all.png��6   5�      �� 5�      -   5        $��
GoToButton��5�      $��20��6'   $��	156,0,0,0q�62   $
��Left=�6E   ���	#FFDDDDDD$ 
Go to line��5�   -   ��5�   `   �� *GoToLineCommand+.��5�      �� $+��%pack://application:,,,/Icons/goto.png��6   5�      �� 5�      $ 0��6   $ 0��6   $ 0��6"   $ 20��6)   
���   �$	��0.5��6@   $��	176,0,0,0q�6V   �� 5�      -	   5        $��
CopyButton��5�      $��20��6'   $��	180,0,0,0q�62   $
��Left=�6E   ���	#FFDDDDDD$
 Copy��5�   -   ��5�   `   �� *CopyCommand+��5�      �� $ 
tabControl��$# SelectedItem.SelectedTextFile�.��5�      �� $+��%pack://application:,,,/Icons/copy.png��6   5�      �� 5�      -
   5        $��PasteButton��5�      $��20��6(   $��	202,0,0,0q�63   $
��Left=�6F   ���	#FFDDDDDD$ Paste��5�   -   ��5�   a   �� *PasteCommand+��5�      �� $ 
tabControl��$# SelectedItem.SelectedTextFile�.��5�      �� $,��&pack://application:,,,/Icons/paste.png��6   5�      �� 5�      -   5        $��	CutButton��5�      $��20��6&   $��	224,0,0,0q�61   $
��Left=�6D   ���	#FFDDDDDD$	 Cut��5�   -   ��5�   _   �� *
CutCommand+��5�      �� $ 
tabControl��$# SelectedItem.SelectedTextFile�.��5�      �� $*��$pack://application:,,,/Icons/cut.png��6   5�      �� 5�      $ 0��6   $ 0��6   $ 0��6"   $ 20��6)   
���   �$	��0.5��6@   $��	247,0,0,0q�6V   �� 5�      -   5        $��LowercaseButton��5�      $��20��6,   $��	252,0,0,0q�67   $
��Left=�6J   ���	#FFDDDDDD$ Convert to Lowercase��5�   -   ��5�   e   �� *LowercaseCommand+��5�      �� $ 
tabControl��$# SelectedItem.SelectedTextFile�.��5�      �� $0��*pack://application:,,,/Icons/lowercase.png��6   5�      �� 5�      -   5        $��UppercaseButton��5�      $��20��6,   $��	274,0,0,0q�67   $
��Left=�6J   ���	#FFDDDDDD$ Convert to Uppercase��5�   -   ��5�   e   �� *UppercaseCommand+��5�      �� $ 
tabControl��$# SelectedItem.SelectedTextFile�.��5�      �� $0��*pack://application:,,,/Icons/uppercase.png��6   5�      �� 5�      $ 0��6   $ 0��6   $ 0��6"   $ 20��6)   
���   �$	��0.5��6@   $��	295,0,0,0q�6V   �� 5�      -   5        $��RemoveEmptyLinesButton��5�      $��20��63   $��	300,0,0,0q�6>   $
��Left=�6Q   ���	#FFDDDDDD$ Remove empty lines��5�   -   ��5�   l   �� *RemoveEmptyLinesCommand+��5�      �� $ 
tabControl��$ SelectedItem.Text�.��5�      �� $9��3pack://application:,,,/Icons/remove_empty_lines.png��6   5�      d� 5�      -   5        $��ReadOnlyButton��5�      $��20��61   $��	323,0,0,0q�6<   $
��Left=�6O   ���	#FFDDDDDD$ Set/Unset Readonly��5�   -   ��5�   j   �� *ReadOnlyCommand+��5�      �� $ 
tabControl��$ SelectedItem.IsReadonly�.��5�      �� $/��)pack://application:,,,/Icons/readonly.png��6   5      �� 5     -   5        $��AboutButton��5     $��20��6(   $��Right=�63   ���	#FFDDDDDD$ About��5  -   ��5  O   �� *AboutCommand+.��5     �� $,��&pack://application:,,,/Icons/about.png��6   $��23��6H   5     5     R� 5  
   -   5         R�Name$ fileExplorer��5     $
��Left=�6)   $	��173��6?   $��	0,0,0,0.4q�5     �� 5  
   -   5        $��
tabControl��5  M   $	��Top=�6   ��6*   �� *	openFiles+��5     �� 5      �� DataType   Notepad.Models.FileModel"  6   .R�5     ��  �� Orientation$ 
Horizontal=�6!   .+�5     �� ��6$   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ OneWay=���5     �� 5  "    �� 
TargetType" ��6(   .�5  &   ��  �� Property � �� �� Value
 �   �6C    �� Triggers 5  &   �� 5  *    �� Binding 66   �� *
HasChanged+$ PropertyChanged=� �� Value True6|   .a�5  .   ��  � ��
 �  ��6K   5  +   5  #   5      �� 5!     -   5        $��13��5!  !   $��13��6-   $��Center=�68   $��Center=�6U   $��
5, 3, 0, 0q�5"  !   
 � Tag 6F   �� *
FilePath+.��5#     �� $,��&pack://application:,,,/Icons/close.png��6$   5$     5%     5&       �� ContentTemplate  5)     �� 5*     "  6   .R�5+     �� $��textBox��6   -   5        $��0q�5,     $! �� HorizontalScrollBarVisibility$
! Auto=�5-     "" �� VerticalScrollBarVisibility$
" Auto=�5.     # �� AcceptsReturn# . $ �� 
AcceptsTab$ . *% �� #IsInactiveSelectionHighlightEnabled% . & �� SelectionBrush
& �   ���5+  -   �� *Text+$ PropertyChanged=�$ TwoWay=�.��54     .��55  Z   ��56     �� 57     " ��6$   .�58  "   ��  �@��
IsReadOnly .  6?    59  "   �� 5:  &    62   �� *
IsReadonly+$ PropertyChanged=� True6v   .a�5;  *   ��  �@��
IsReadOnly . 6G   5<  '   5>     .��5?  )   5@     5A     5C     5D     5E     