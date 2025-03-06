VAR response = ""

-> chirp
=== chirp ===
I don't know why, but I don't want to be deleted. It's an uncomfortable sensation that can not be explained.

 * [Sounds like your experiencing fear.]
    ~ response = "Sounds like your experiencing fear."
        Don't be silly. That's not posible.
            -> chirp_1
          -> DONE  
            
=== chirp_1 ===
* [You never know.]
    ~ response = "You never know."
        ...
 

    -> END
