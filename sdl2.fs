\ SDL2 bindings for Gforth
\ SDL2 docs: https://wiki.libsdl.org/CategoryAPI

c-library sdl2
\c #include <SDL2/SDL.h>

s" SDL2" add-lib

c-function SDL_Init            SDL_Init            n -- n
c-function SDL_CreateWindow    SDL_CreateWindow    a n n n n n -- a \ First arg is a C string
c-function SDL_Quit            SDL_Quit            -- void
c-function SDL_CreateRenderer  SDL_CreateRenderer  a n n -- a
c-function SDL_CreateTexture   SDL_CreateTexture   a n n n n -- a
c-function SDL_UpdateTexture   SDL_UpdateTexture   a a a n -- n
c-function SDL_DestroyWindow   SDL_DestroyWindow   a -- void
c-function SDL_DestroyRenderer SDL_DestroyRenderer a -- void
c-function SDL_DestroyTexture  SDL_DestroyTexture  a -- void
c-function SDL_GetError        SDL_GetError        -- a \ C string
c-function SDL_RenderClear     SDL_RenderClear     a -- n
c-function SDL_RenderCopy      SDL_RenderCopy      a a a a -- n
c-function SDL_RenderPresent   SDL_RenderPresent   a -- void
c-function SDL_GetTicks        SDL_GetTicks        -- n
c-function SDL_Delay           SDL_Delay           n -- void

end-c-library

\ Constants and definitions for SDL.

HEX
0001 CONSTANT SDL_INIT_TIMER
0010 CONSTANT SDL_INIT_AUDIO
0020 CONSTANT SDL_INIT_VIDEO
0200 CONSTANT SDL_INIT_JOYSTICK
1000 CONSTANT SDL_INIT_HAPTIC
2000 CONSTANT SDL_INIT_GAMECONTROLLER
4000 CONSTANT SDL_INIT_EVENTS
7231 CONSTANT SDL_INIT_EVERYTHING

0 CONSTANT NULL
1 CONSTANT SDL_RENDERER_SOFTWARE
2 CONSTANT SDL_RENDERER_ACCELERATED
4 CONSTANT SDL_RENDERER_PRESENTVSYNC
8 CONSTANT SDL_RENDERER_TARGETTEXTURE

0001 CONSTANT SDL_WINDOW_FULLSCREEN
0002 CONSTANT SDL_WINDOW_OPENGL
0004 CONSTANT SDL_WINDOW_SHOWN
0008 CONSTANT SDL_WINDOW_HIDDEN
0010 CONSTANT SDL_WINDOW_BORDERLESS
0020 CONSTANT SDL_WINDOW_RESIZABLE
0040 CONSTANT SDL_WINDOW_MINIMIZED
0080 CONSTANT SDL_WINDOW_MAXIMIZED
0100 CONSTANT SDL_WINDOW_INPUT_GRABBED
0200 CONSTANT SDL_WINDOW_INPUT_FOCUS
0400 CONSTANT SDL_WINDOW_MOUSE_FOCUS
0800 CONSTANT SDL_WINDOW_FOREIGN
2000 CONSTANT SDL_WINDOW_ALLOW_HIGHDPI
1001 CONSTANT SDL_WINDOW_FULLSCREEN_DESKTOP

0 CONSTANT SDL_TEXTUREACCESS_STATIC
1 CONSTANT SDL_TEXTUREACCESS_STREAMING
2 CONSTANT SDL_TEXTUREACCESS_TARGET

16362004 CONSTANT SDL_PIXELFORMAT_ARGB8888
DECIMAL


\ General C string helpers

\ Returns a transient(!) C-string of the provided string.
\ Uses the PAD as a scratch area.
: >c-str ( c-addr u -- c-addr ) pad swap   dup >r   move  0   pad r> + c! pad ;

\ Returns the provided C-string as a Forth two-part string.
\ Effectively, dup strlen.
: c-str> ( c-addr -- c-addr u ) 0 BEGIN 2dup + c@ WHILE 1+ REPEAT ;
