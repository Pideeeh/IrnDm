/*#define PI 3.14159265358979323846*/
#define MINFILTERWIDTH 1.0e-6
#define GS_MINFILTERWIDTH 1.0e-6

#define gs_AA(x) (abs(Du(x)*du) + abs(Dv(x)*dv))
#define gs_sq(x) 		(x * x)
#define gs_square(x) ((x)*(x))
#define gs_cube(x) 		((x)*(x)*(x))
#define gs_quad(x) 		((x)*(x)*(x)*(x))
#define gs_shift(x) 		((x+1)/2)
#define gs_radius(a,b) 	(sqrt(a*a+b*b))
#define gs_aasize(x) 	(max(length(Du(x)*du),length(Dv(x)*dv)))
#define gs_blend(b,w,x) 	(smoothstep(b-w,b+w,x))
#define gs_luminence(c) 	((comp(c,0)+comp(c,1)+comp(c,2))/3)
#define gs_lum(c) 	((comp(c,0)+comp(c,1)+comp(c,2))/3)
#define gs_snoiseC(c) 	(2* color noise(c) - 1)
#define gs_snoiseP(p) 	(2* point noise(p) - 1)
#define gs_snoiseV(v) 	(2*vector noise(v) - 1)
#define gs_snoiseN(n) 	(2*normal noise(n) - 1)
#define gs_snoise(a)  	(2* float noise(a) - 1)
#define gs_snoiseT(p,t) 	(2*noise(p,t)-1)
#define gs_bias(x,b) 	(pow(x,log(b)/log(0.5))
#define gs_blendwidth(x,y) 	(floor(x)*(1-2*y)+max(0,mod(x,1)-y))
#define gs_fuzzy(a,b,zz,x) 	(smoothstep(a-zz,a,x)*(1-smoothstep(b,b+zz,x)))
#define gs_filterwidth(x) 	(max((abs(Du(x)*du)+abs(Dv(x)*dv)),MINFILTERWIDTH))
#define gs_filteredpulse(a,b,x,w) (max(0,(min(x-w/2,a)-max((x-w/2)+w,b))/w))
#define gs_ripples(a,b,x,y,w) (gs_shift(cos((2*PI*w)+2*\
		PI*gs_radius(a*(x-.5),b*(y-.5)))))
#define gs_pulse(B,W,X) \
	(smoothstep(0.5-(B)-(W), 0.5-(B),     X) - \
	 smoothstep(0.5+(B)    , 0.5+(B)+(W), X))
/*#define gs_blendwidth(x,y) (floor(x)*(1-2*y) + max(0,mod(x,1)-y))*/
#define gs_FUZ(x,aa) ((smoothstep(0.5,0.5+aa,x))+(1-smoothstep(0,aa,x)))
#define gs_BLEND(x,y) (((x)*(y))+((1-(x))*(1-(y))))
#define gs_skin(fx,fy,x,y) (gs_sq(noise((gs_shift(sin(PI*fx*x)) + \
					 gs_shift(cos(PI*fy*y)))/ 2)))

#define GS_AA(x) (abs(Du(x)*du) + abs(Dv(x)*dv))
#define GS_sq(x) 		((x)*(x))
#define GS_square(x) ((x)*(x))
#define GS_cube(x) 		((x)*(x)*(x))
#define GS_quad(x) 		((x)*(x)*(x)*(x))
#define GS_shift(x) 		((x+1)/2)
#define GS_radius(a,b) 	(sqrt(a*a+b*b))
#define GS_aasize(x) 	(max(length(Du(x)*du),length(Dv(x)*dv)))
#define GS_blend(b,w,x) 	(smoothstep(b-w,b+w,x))
#define GS_luminence(c) 	((comp(c,0)+comp(c,1)+comp(c,2))/3)
#define GS_lum(c) 	((comp(c,0)+comp(c,1)+comp(c,2))/3)
#define GS_snoiseC(c) 	(2* color noise(c) - 1)
#define GS_snoiseP(p) 	(2* point noise(p) - 1)
#define GS_snoiseV(v) 	(2*vector noise(v) - 1)
#define GS_snoiseN(n) 	(2*normal noise(n) - 1)
#define GS_snoise(a)  	(2* float noise(a) - 1)
#define GS_snoiseT(p,t) 	(2*noise(p,t)-1)
#define GS_bias(x,b) 	(pow(x,log(b)/log(0.5))
#define GS_blendwidth(x,y) 	(floor(x)*(1-2*y)+max(0,mod(x,1)-y))
#define GS_fuzzy(a,b,zz,x) 	(smoothstep(a-zz,a,x)*(1-smoothstep(b,b+zz,x)))
#define GS_filterwidth(x) 	(max((abs(Du(x)*du)+abs(Dv(x)*dv)),MINFILTERWIDTH))
#define GS_filteredpulse(a,b,x,w) (max(0,(min(x-w/2,a)-max((x-w/2)+w,b))/w))
#define GS_ripples(a,b,x,y,w) (gs_shift(cos((2*PI*w)+2*\
		PI*gs_radius(a*(x-.5),b*(y-.5)))))
#define GS_pulse(B,W,X) \
	(smoothstep(0.5-(B)-(W), 0.5-(B),     X) - \
	 smoothstep(0.5+(B)    , 0.5+(B)+(W), X))
/*#define GS_blendwidth(x,y) (floor(x)*(1-2*y) + max(0,mod(x,1)-y))*/
#define GS_FUZ(x,aa) ((smoothstep(0.5,0.5+aa,x))+(1-smoothstep(0,aa,x)))
#define GS_BLEND(x,y) (((x)*(y))+((1-(x))*(1-(y))))
#define GS_skin(fx,fy,x,y) (GS_sq(noise((GS_shift(sin(PI*fx*x)) + \
					 GS_shift(cos(PI*fy*y)))/ 2)))
