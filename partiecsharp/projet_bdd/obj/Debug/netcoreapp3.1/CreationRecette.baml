   M S B A M L   `   `   `  ����E  Aprojet_bdd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:projet_bdd
projet_bdd  5   	        projet_bdd.CreationRecette   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:projet_bdd     5   	     � Title$  CreationRecette��5   	    � AllowsTransparency$
 True��6!   $	��720��6;   $
��1080��6H   
������  � WindowStyle$
 None=�5	   	    � 
ResizeMode$ CanResizeWithGrip=�6    � WindowStartupLocation$ CenterScreen=�6;   .��5
      � ���#E4F1FE.+�5      �� $(��"Création d'une nouvelle recette :��6   $��30(�6A   $��Center=�6O   $	��Top=�6l   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Center=�6M   .+�5      �� $ Vertical=�6   $��50,10q�64   .+�5      �� $��Nom de la recette :��6   $��10q�6:   $��Center=�6F   $
��Bold"�6c   �� 5      -   5        $��
nomrecette��5      $��10q�60   ���#87AECC �� SelectionTextBrush �#87AECC��6o   Z� �� 5      $��Descriptif :��6   $��10q�63   $��Center=�6?   $
��Bold"�6\   �� 5      -   5        $��
descriptif��5      $��10q�60   ���	#FFE0D8D8 �	#FF1D1B1B$	��100��6r   $	��200��6   �� 5      $ 
Horizontal=�6!   .+�5      �� -   5        $��entree��5   #   $��Entrée��61   $��10q�6B   �� 5      -   5        $
��plat��5   #   $
��Plat��6/   $��10q�6>   �� 5      -   5        $��dessert��5   #   $��Dessert��62   $��10q�6D   5      �� 5      $)��#Ne pas cocher plusieurs catégories��6   $��Center=�6I   $��Normal"�6f   $��Italic$�6z   
���  ����6�   Z� 6�   5      �� 5      $ Vertical=�6   $
��0,10q�65   .+�5      �� $��Prix de la recette :��6   $��10q�6;   $��Center=�6G   $��Normal$�6d   $
��Bold"�6w   �� 5      $ 
Horizontal=�6!   $��Center=�6:   .+�5      �� -   5         ��Name$
 prix��5   "   $��10q�60   $��40��6<   ���	#FFE0D8D8 �	#FF1D1B1B6^   �� 5      $��Cooks��6    $��10q�60   $��40��6<   $��Italic$�6G   5       �� 5!      $��Liste des ingredients :��6   $��Center=�6>   $
��Bold"�6[   �� 5"      $ 
Horizontal=�6!   $
��Left=�6:   $��5,-10q�6U   .+�5#      �� -   5        $��
ingredient��5#   #   $��20q�65   $	��100��6A   5$      �� 5%      -   5        $��nombre��5%   "   $��20q�60   $��30��6<   �� 5'      -	   5        $��Ajouter ingrédient��5'   !   ���#F7CA18$��Segoe UI Black)�6a   $��12(�6}   $��10q�6�   $��25��6�   ��6�   Z� 6�   5*      �� 5+      $ Vertical=�6!   $
��Left=�68   $
��20,0q�6S   .+�5,      �� $��Center=�6    $#��Liste d'ingredients choisis :��6D   $��10q�6l   $��Center=�6x   $��20(�6�   $��Normal$�6�   $
��Bold"�6�   �� 5-      $ 
Horizontal=�6%   $
��Left=�6>   $
��20,0q�6Y   .+�5.      �� -
   5        $��listBox1��5.   &   $��Center=�66   $	��120��6T   $	��200��6a   ���	#FFEEF9E8$��11(�6�   �� 5/      -   5        $��Supprimer un ingredient��5/   %   $��Center=�6G   ���#F7CA18$��Segoe UI Black)�6�   $��11(�6�   $��10q�6�   $��30��6�   51      52      53      54      �� 55      $ 
Horizontal=�6   $��Center=�62   $��10q�6O   $��Bottom=�6[   .+�56      �� -   5        $��Retour��56      $	��100��6*   ���#F7CA18$��Segoe UI Black)�6Z   $��16(�6v   �� 57      -   5        $��Valider��57      $	��100��6+   ���#F7CA18$��Segoe UI Black)�6_   $��16(�6{   58      5:      5;      