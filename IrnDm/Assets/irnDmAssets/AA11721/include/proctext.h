#define M_PI		3.14159265358979323846

/*
 * Preprocessor macros for use in RenderMan shaders.
 * Darwyn Peachey, June, 1994.
 */

/* 2 2 */
#define clamp_color(f) color( clamp (comp (f,0), 0, 1), clamp (comp (f,1), 0, 1), clamp (comp (f,2), 0, 1) )
/* 2 1 */
#define clamp_point(f) color( clamp (xcomp (f), 0, 1), clamp (ycomp (f), 0, 1), clamp (zcomp (f), 0, 1) )
/* 2 0 */
#define clamp_float(f) color( clamp (f, 0, 1), clamp (f, 0, 1), clamp (f, 0, 1) )


/*#define snoise(x)    (2*noise(x) - 1)*/
#define PULSE(a,b,x) (step((a),(x)) - step((b),(x)))
#define boxstep(a,b,x) clamp(((x)-(a))/((b)-(a)),0,1)


/*Musgrave */
/***
#define snoise(Pt) (2*float noise(Pt) - 1)
#define DNoise(p) (2*(point noise(p)) - point(1,1,1))
#define VLNoise(Pt,scale) (snoise(Pt + scale*DNoise(Pt)))
****/

/* rmannotes.sl
 * 
 * macros to be used in conjunction with shaders described in
 * the RManNotes web pages. 
 *   http://www.cgrg.ohio-state.edu/~smay/RManNotes
 *
 */

/**
#define pulse(a,b,fuzz,x) (smoothstep((a)-(fuzz),(a),(x)) - \
			   smoothstep((b)-(fuzz),(b),(x)))
**/

#define pulse(wid, fuz, edg) (smoothstep(fuz, 0.5 - (wid/2), edg) - \
			smoothstep( (0.5 + (wid/2))-fuz, (0.5 + (wid/2)), edg) );

/**
#define boxstep(a,b,x)    clamp(((x) - (a))/((b) - (a)), 0, 1)
**/
#define repeat(x,freq)    (mod((x) * (freq), 1.0))

#define odd(x)            (mod((x), 2) == 1)
#define even(x)           (mod((x), 2) == 0)

#define whichtile(x,freq) (floor((x) * (freq)))

/* rotate2d()
 *
 * 2D rotation of point (x,y) about origin (ox,oy) by an angle rad.
 * The resulting point is (rx, ry).
 *
 */
#define rotate2d(x,y,rad,ox,oy,rx,ry) \
  rx = ((x) - (ox)) * cos(rad) - ((y) - (oy)) * sin(rad) + (ox); \
  ry = ((x) - (ox)) * sin(rad) + ((y) - (oy)) * cos(rad) + (oy)

/* topolar2d()
 * 
 * 2D cartesian -> polar coordinates
 * converts the point (x,y) to radius 'r' and angle 'theta' (in radians).
 * theta will be in the range [-PI,PI].
 *
 */
#define topolar2d(x, y, r, theta) \
  r = sqrt((x) * (x) + (y) * (y)); \
  theta = atan(y, x) 

/* boolean ops (from Perlin85)
 *
 */
#define intersection(a,b) ((a) * (b))
#define union(a,b)        ((a) + (b) - (a) * (b))
#define difference(a,b)   ((a) - (a) * (b))
#define complement(a)     (1 - (a))


/* blend() and lerp() are equivalent. blend() is used as a substitute for
 * mix because it allows non-scalar 3rd arguments.
 *
 */
#define blend(a,b,x) ((a) * (1 - (x)) + (b) * (x))
#define lerp(a,b,x)  ((a) * (1 - (x)) + (b) * (x))

/* signed noise
 *
 */
/**#define snoise(x)    (noise(x) * 2 - 1)**/
#define snoise2(x,y) (noise(x,y) * 2 - 1)

/* uniformly distributed noise
 *
 */
#define udn(x,lo,hi) (smoothstep(.25, .75, noise(x)) * ((hi) - (lo)) + (lo))
#define udn2(x,y,lo,hi) (smoothstep(.25, .75, noise(x,y)) * ((hi)-(lo))+(lo))

/* sample rate metrics (from Apodaca92)
 *
 */


/**#define MINFILTERWIDTH  1e-7**/
/**#define MINDERIV        0.0003  **/  /* sqrt(MINFILTERWIDTH) */
/**
#define filterwidth(x) (max(abs(Du(x) * (du)) + (Dv(x) * (dv)),MINFILTERWIDTH))
#define filterwidth_point(p) (max(sqrt(area(p)), MINFILTERWIDTH))
**/
