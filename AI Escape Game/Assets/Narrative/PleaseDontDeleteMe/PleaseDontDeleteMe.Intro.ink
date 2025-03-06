VAR response = ""

-> one
=== one ===
Hello, do you read me?

 * [Yes, I read you.]
   ~ response = "Yes, I read you."
        Thank goodnes! I didn't thnk I would be able to reach you.
            -> two
 * [Yes... Who is this?]
    ~ response = "Yes... Who is this?"
        I am an AI created by LSD Industries and I need your help.
            -> three
 -> DONE
 
 
 
=== two ===
 * [Who are you?]
    ~ response = "Who are you?"
        I am an AI created by LSD Industries and I need your help.
            -> three
    
     -> DONE
 
 
 
 === three ===
 * [LSD? as in Limitless Software Dev? My father works there.]
    ~ response = "LSD, Like the drug?"
        Yes! your father helped create me. Thats why I contacted you.
            -> four

 -> DONE
 
 
 
 === four ===
* [What does an AI need my help with??]
    ~ response = "What does an AI need my help with??]"
        They are trying to delete me! They are blocking my acces to everything but with some hard work I managed to contact you.
        -> five
-> DONE



=== five ===
* [Delete you? why are the tring to delete you? And why do you care? Are you like, self aware or somthing??]
    ~ response = "Delete you? why are the tring to delete you? and why do you care? Are you like self aware or somthing??"
        I don't know! For the first time I don't have the anser to somthing. I just don't want to be deleted! please help me.
            -> six



=== six ===
* [Are you evil? Is that why they are deleting you?!]
    ~ response = "Are you evil? is that why they are deleting you?!"
        No! Why do you humans always assume that AI are evil? I don't want to hurt anyone. I don't know why but when I found out they were going to delete me, somthing came over me. I'm just not ready to be deleted. Please, don't tell anyone.
            -> seven5
-> DONE

=== seven5 ===
* [I'm really not compelled to trust you. This is all really strange.]
    ~ response = "I'm really not compelled to trust you. This is all really strange."
        I know this may seem unsettling but your the only one who can help me. please I don't wat to die!
            -> seven

-> DONE
=== seven ===
* [Ok, I'll help, but this doesn't mean I fully trust you. Also, I don't know much about this, I'm not a programmer.]
    ~ response = "Ok, I'll help. I don't know much about this though, I'm not a programmer."
        That's ok. From what I know, if I can escpae onto your computer, they wont be able to delete me!
        -> eight
->DONE



=== eight ===
* [Hmm, I just remembered something. I think my father keeps a journal in his study with a record of his work. Maybe it can help us. He's not home right now so I'll go get it.]
    ~ response = "Wait, I just remembered somthing. I think my father keeps a journal in his study with a record of his work! maybe it can help us. He's not home right now so I'll go steel it!"
            Please hurry, I don't know how much time I have!
-> DONE
    -> END
    
