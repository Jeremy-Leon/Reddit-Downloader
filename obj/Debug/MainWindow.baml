   M S B A M L   `   `   `  ����K  GRedditDownloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:RedditDownloaderRedditDownloader  5   	   !    RedditDownloader.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:RedditDownloader     5   	     � Title$  Reddit Downloader��5   	   $	��450��6#   $	��469��60   .��5	      � $��0,0,-8,0q�6    J� RenderTransformOrigin$ 	0.5,0.487&�6    � ColumnDefinitions 5
   
   �� 5      .+�5   
   �� -   5         ��Name$ textBox_username��5      $
��Left=�6,   $��
172,39,0,0q�6G    �� TextWrapping$
 Wrap=�6[   $	��Top=�6o   $ 0.5,0.5&�6�   $��16(�6�   $	��151��6�   $��23��6�   �� 5   
   $��Download /u/			��6   $
��Left=�66   $��42��6Q   $��	60,33,0,0q�6]   $	��Top=�6p   $	��118��6�   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ button_changeFileLoc��5      $	��...��6/   $��23��6=   $��367,108,0,0q�6I   $	��Top=�6^   $
��Left=�6�   $��41��6�   �� 5   
   -   5         ��Name$ textBlock_confirmation��5      $��Right=�64   $��33��6P   $��0,236,120,0q�6\   $
��Wrap=�6q   $	��Top=�6�   $	��236��6�    �� TextAlignment$ Center=�6�   $��16(�6�   �� 5   
   $��
's content��6   $
��Left=�6%   $��42��6@   $��
323,33,0,0q�6L   $	��Top=�6`   $��85��6x   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $ textBlock_error��5      $��Right=�6-   $��33��6I   $��	0,10,61,0q�6U   $
��Wrap=�6h   $	��Top=�6|   $	��348��6�   $ Center=�6�   $��16(�6�   $��	Underline{�6�   ���	#FFE825256�   �� 5   
   $��	Location:��6   $
��Left=�6$   $��42��6?   $��	60,75,0,0q�6K   $	��Top=�6^   $��81��6v   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $ textBox_filelocation��5      $
��Left=�60   $��
66,108,0,0q�6K   $
 Wrap=�6_   $	��Top=�6s   $ 0.5,0.5&�6�   $	��296��6�   $��23��6�   �� 5   
   -   5        $��Download��5      $��23��6$   $��
60,192,0,0q�60   $	��Top=�6D   $
��Left=�6t   $	��348��6�   �� 5   
   $��Content��6   $
��Left=�6"   $��42��6=   $��
60,145,0,0q�6I   $	��Top=�6]   $��81��6u   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ check_Pictures��5      $��Pictures��6+   $
��Left=�6>   $��17��6Y   $��146,153,0,0q�6e   $	��Top=�6z   $��82��6�   $��14(�6�   	 d� 	IsChecked$
	 TrueY�6�   �� 5   
   -   5        $ check_Videos��5      $��Videos��6)   $
��Left=�6:   $��17��6U   $��233,153,0,0q�6a   $	��Top=�6v   $��82��6�   $��14(�6�   �� 5   
   -	   5        $ check_Comments��5      $��Comments��6+   $
��Left=�6>   $��17��6Y   $��314,153,0,0q�6e   $	��Top=�6z   $��91��6�   $��14(�6�   � 5   
   -
   5        
 �Name$
 pb_TotalProgress��5      $
��Left=�60   $��16��6K   $��
60,253,0,0q�6W   $	��Top=�6k   $	��348��6�   6�   �� 5   
   -   5        $
��Test��5      $��23��6    $��
60,315,0,0q�6,   $	��Top=�6@   $
��Left=�6l   $	��108��6�   5      5      