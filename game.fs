\ Gforth SDL2 Game Starter
\ To run, install Gforth, then in terminal: gforth sdl2.fs game.fs

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

\ The renderer
NULL VARIABLE renderer

SDL_INIT_VIDEO SDL_Init                                \ start sdl		
\ 0<> s" Unable to initialize SDL" Error-End

window_title SCREEN_WIDTH SCREEN_HEIGHT 128 128 0 SDL_CreateWindow   \ create window
-1 0 SDL_CreateRenderer \ create renderer

SDL_PIXELFORMAT_ARGB8888 SDL_TEXTUREACCESS_STREAMING SCREEN_WIDTH SCREEN_HEIGHT SDL_CreateTexture

SDL_RenderClear

\ 100 100 SDL_RenderDrawPoint point \ create point

renderer SDL_RenderPresent

1000 SDL_Delay

renderer SDL_DestroyRenderer
window SDL_DestroyWindow

SDL_Quit
