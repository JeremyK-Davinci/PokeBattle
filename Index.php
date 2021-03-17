<?php 
    require ("Classes/Type.php");
    print_r('<pre>'.$Types[4].'</pre>');

    require ("Classes/Attack.php");

    $Scratch = new Attack('Scratch', '15', 'Normal');
    print_r('<pre>'.$Scratch.'</pre>');

    $Lick = new Attack('Lick', '10', 'Ghost');
    print_r('<pre>'.$Lick.'</pre>');

    $type = $Types[4];
    $resistant = $type->isRessistant($Lick->type) == 1 ? 'true' : 'false';
    echo $type->name . ' Is Resistant To ' . $Lick->name . ' : ' . $resistant;