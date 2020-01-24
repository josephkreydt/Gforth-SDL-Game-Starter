\ Gforth SDL2 Game Starter

require sdl2.fs

: Terminate-String ( a n -- a )    \ replaces the last character of a
  over + 1- 0 swap c!                                \ string with \0
;

\ Screen dimensions
640 CONSTANT SCREEN_WIDTH
640 CONSTANT SCREEN_HEIGHT

s" Game Name" Terminate-String VARIABLE window_title

\ The window we'll be rendering to
NULL VARIABLE window

SDL_INIT_VIDEO SDL_Init                                \ start sdl		
\ 0<> s" Unable to initialize SDL" Error-End

window_title SCREEN_WIDTH SCREEN_HEIGHT 128 128 0 SDL_CreateWindow window   \ create window

10000 SDL_Delay

window SDL_DestroyWindow

SDL_Quit
