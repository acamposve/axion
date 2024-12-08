(function(){"use strict";var e={6062:function(e,t,a){var r=a(5130),o=a(6768);const n={id:"app"};function i(e,t,a,r,i,s){const c=(0,o.g2)("router-view");return(0,o.uX)(),(0,o.CE)("div",n,[(0,o.bF)(c)])}var s={name:"App"},c=a(1241);const l=(0,c.A)(s,[["render",i]]);var d=l,u=a(1387);const p={class:"container mt-5"},m={class:"row justify-content-center"},g={class:"col-md-4"},b={class:"mb-3"},h={class:"mb-3"};function k(e,t,a,n,i,s){return(0,o.uX)(),(0,o.CE)("div",p,[(0,o.Lk)("div",m,[(0,o.Lk)("div",g,[t[6]||(t[6]=(0,o.Lk)("h2",{class:"text-center"},"Admin Login",-1)),(0,o.Lk)("form",{onSubmit:t[2]||(t[2]=(0,r.D$)(((...e)=>s.login&&s.login(...e)),["prevent"]))},[(0,o.Lk)("div",b,[t[3]||(t[3]=(0,o.Lk)("label",{for:"login",class:"form-label"},"Login:",-1)),(0,o.bo)((0,o.Lk)("input",{"onUpdate:modelValue":t[0]||(t[0]=e=>i.loginData.login=e),type:"text",class:"form-control",id:"login",required:""},null,512),[[r.Jo,i.loginData.login]])]),(0,o.Lk)("div",h,[t[4]||(t[4]=(0,o.Lk)("label",{for:"password",class:"form-label"},"Password:",-1)),(0,o.bo)((0,o.Lk)("input",{"onUpdate:modelValue":t[1]||(t[1]=e=>i.loginData.password=e),type:"password",class:"form-control",id:"password",required:""},null,512),[[r.Jo,i.loginData.password]])]),t[5]||(t[5]=(0,o.Lk)("button",{type:"submit",class:"btn btn-primary w-100"},"Login",-1))],32)])])])}a(4114);var f=a(4373),y={data(){return{loginData:{login:"",password:""}}},methods:{async login(){try{const e=await f.A.post("http://amontefusco-002-site1.ktempurl.com/api/admin/login",this.loginData);localStorage.setItem("adminToken",e.data.token),this.$router.push("/dashboard")}catch(e){console.error("Error during login",e)}}}};const L=(0,c.A)(y,[["render",k]]);var v=L;function C(e,t,a,r,n,i){const s=(0,o.g2)("router-link");return(0,o.uX)(),(0,o.CE)("div",null,[t[2]||(t[2]=(0,o.Lk)("h1",null,"Admin Dashboard",-1)),t[3]||(t[3]=(0,o.Lk)("p",null,"Bienvenido, Admin!",-1)),(0,o.bF)(s,{to:"/categories"},{default:(0,o.k6)((()=>t[0]||(t[0]=[(0,o.eW)("Ir a Categorías")]))),_:1}),t[4]||(t[4]=(0,o.eW)(" | ")),(0,o.bF)(s,{to:"/products"},{default:(0,o.k6)((()=>t[1]||(t[1]=[(0,o.eW)("Ir a Productos")]))),_:1})])}var w={name:"AdminDashboard"};const I=(0,c.A)(w,[["render",C]]);var $=I,A=a(4232);const F={class:"container mt-5"},P={class:"card"},x={class:"card-body"},E={class:"list-group"},D=["onClick"],X=["onClick"],U={class:"text-center mt-3"};function V(e,t,a,r,n,i){return(0,o.uX)(),(0,o.CE)("div",F,[t[1]||(t[1]=(0,o.Lk)("h2",{class:"text-center"},"Category List",-1)),(0,o.Lk)("div",P,[(0,o.Lk)("div",x,[(0,o.Lk)("ul",E,[((0,o.uX)(!0),(0,o.CE)(o.FK,null,(0,o.pI)(n.categories,(e=>((0,o.uX)(),(0,o.CE)("li",{class:"list-group-item d-flex justify-content-between align-items-center",key:e.id},[(0,o.eW)((0,A.v_)(e.name)+" ",1),(0,o.Lk)("div",null,[(0,o.Lk)("button",{class:"btn btn-warning btn-sm me-2",onClick:t=>i.editCategory(e.id)},"Edit",8,D),(0,o.Lk)("button",{class:"btn btn-danger btn-sm",onClick:t=>i.deleteCategory(e.id)},"Delete",8,X)])])))),128))]),(0,o.Lk)("div",U,[(0,o.Lk)("button",{class:"btn btn-primary",onClick:t[0]||(t[0]=(...e)=>i.createNewCategory&&i.createNewCategory(...e))},"Add New Category")])])])])}const q="http://amontefusco-002-site1.ktempurl.com/api";var N={getAllCategories(){return f.A.get(`${q}/categories/all`)},getCategory(e){return f.A.get(`${q}/categories/${e}`)},createCategory(e){return f.A.post(`${q}/categories/create`,e)},updateCategory(e,t){return f.A.put(`${q}/categories/${e}`,t)},deleteCategory(e){return f.A.delete(`${q}/categories/${e}`)}},J={data(){return{categories:[]}},async created(){const e=await N.getAllCategories();this.categories=e.data},methods:{createNewCategory(){this.$router.push("/categories/new")},editCategory(e){this.$router.push(`/categories/${e}/edit`)},async deleteCategory(e){await N.deleteCategory(e),this.categories=this.categories.filter((t=>t.id!==e))}}};const O=(0,c.A)(J,[["render",V]]);var S=O;const _={class:"container mt-5"},j={class:"card"},T={class:"card-body"},H={class:"mb-3"},z={class:"mb-3"},W={class:"mb-3"},K={class:"text-center"};function M(e,t,a,n,i,s){return(0,o.uX)(),(0,o.CE)("div",_,[t[9]||(t[9]=(0,o.Lk)("h2",{class:"text-center"},"Crear Nueva Categoría",-1)),(0,o.Lk)("div",j,[(0,o.Lk)("div",T,[(0,o.Lk)("form",{onSubmit:t[4]||(t[4]=(0,r.D$)(((...e)=>s.createCategory&&s.createCategory(...e)),["prevent"]))},[(0,o.Lk)("div",H,[t[5]||(t[5]=(0,o.Lk)("label",{for:"name",class:"form-label"},"Nombre:",-1)),(0,o.bo)((0,o.Lk)("input",{"onUpdate:modelValue":t[0]||(t[0]=e=>i.name=e),type:"text",id:"name",class:"form-control",required:"",placeholder:"Ingresa el nombre de la categoría"},null,512),[[r.Jo,i.name]])]),(0,o.Lk)("div",z,[t[6]||(t[6]=(0,o.Lk)("label",{for:"description",class:"form-label"},"Descripción:",-1)),(0,o.bo)((0,o.Lk)("textarea",{"onUpdate:modelValue":t[1]||(t[1]=e=>i.description=e),id:"description",class:"form-control",required:"",placeholder:"Ingresa una descripción"},null,512),[[r.Jo,i.description]])]),(0,o.Lk)("div",W,[t[7]||(t[7]=(0,o.Lk)("label",{for:"image",class:"form-label"},"Imagen:",-1)),(0,o.Lk)("input",{onChange:t[2]||(t[2]=(...e)=>s.onFileChange&&s.onFileChange(...e)),type:"file",id:"image",class:"form-control",accept:"image/*"},null,32)]),(0,o.Lk)("div",K,[t[8]||(t[8]=(0,o.Lk)("button",{type:"submit",class:"btn btn-primary"},"Crear Categoría",-1)),(0,o.Lk)("button",{type:"button",class:"btn btn-secondary ms-3",onClick:t[3]||(t[3]=t=>e.$router.push("/categories"))},"Cancelar")])],32)])])])}var Q={data(){return{name:"",description:"",image:null}},methods:{onFileChange(e){this.image=e.target.files[0]},async createCategory(){const e=new FormData;e.append("name",this.name),e.append("description",this.description),e.append("image",this.image);try{await f.A.post("http://amontefusco-002-site1.ktempurl.com/api/Categories/create",e,{headers:{"Content-Type":"multipart/form-data"}}),this.$router.push("/categories")}catch(t){console.error("Error creando la categoría:",t),alert("Hubo un error al crear la categoría. Inténtalo de nuevo.")}this.name="",this.description="",this.image=null}}};const B=(0,c.A)(Q,[["render",M]]);var G=B;const R={class:"container mt-5"},Y={class:"card"},Z={class:"card-body"},ee={class:"mb-3"},te={class:"mb-3"},ae={class:"mb-3"},re={class:"mt-2"},oe=["src"],ne={class:"mb-3"},ie={class:"text-center"};function se(e,t,a,n,i,s){return(0,o.uX)(),(0,o.CE)("div",R,[t[10]||(t[10]=(0,o.Lk)("h2",{class:"text-center"},"Editar Categoría",-1)),(0,o.Lk)("div",Y,[(0,o.Lk)("div",Z,[(0,o.Lk)("form",{onSubmit:t[4]||(t[4]=(0,r.D$)(((...e)=>s.updateCategory&&s.updateCategory(...e)),["prevent"]))},[(0,o.Lk)("div",ee,[t[5]||(t[5]=(0,o.Lk)("label",{for:"name",class:"form-label"},"Nombre:",-1)),(0,o.bo)((0,o.Lk)("input",{"onUpdate:modelValue":t[0]||(t[0]=e=>i.name=e),type:"text",id:"name",class:"form-control",required:"",placeholder:"Ingresa el nombre de la categoría"},null,512),[[r.Jo,i.name]])]),(0,o.Lk)("div",te,[t[6]||(t[6]=(0,o.Lk)("label",{for:"description",class:"form-label"},"Descripción:",-1)),(0,o.bo)((0,o.Lk)("textarea",{"onUpdate:modelValue":t[1]||(t[1]=e=>i.description=e),id:"description",class:"form-control",required:"",placeholder:"Ingresa una descripción"},null,512),[[r.Jo,i.description]])]),(0,o.Lk)("div",ae,[t[7]||(t[7]=(0,o.Lk)("label",null,"Imagen Actual:",-1)),(0,o.Lk)("div",re,[i.image?((0,o.uX)(),(0,o.CE)("img",{key:0,src:i.image,alt:"Imagen Actual",class:"img-thumbnail",style:{width:"150px",height:"auto"}},null,8,oe)):(0,o.Q3)("",!0)])]),(0,o.Lk)("div",ne,[t[8]||(t[8]=(0,o.Lk)("label",{for:"image",class:"form-label"},"Cambiar Imagen:",-1)),(0,o.Lk)("input",{onChange:t[2]||(t[2]=(...e)=>s.onFileChange&&s.onFileChange(...e)),type:"file",id:"image",class:"form-control",accept:"image/*"},null,32)]),(0,o.Lk)("div",ie,[t[9]||(t[9]=(0,o.Lk)("button",{type:"submit",class:"btn btn-primary"},"Actualizar Categoría",-1)),(0,o.Lk)("button",{type:"button",class:"btn btn-secondary ms-3",onClick:t[3]||(t[3]=t=>e.$router.push("/categories"))},"Cancelar")])],32)])])])}var ce={data(){return{name:"",description:"",image:null,newImage:null}},methods:{async fetchCategory(){try{const e=await f.A.get(`http://amontefusco-002-site1.ktempurl.com/api/categories/${this.$route.params.id}`);this.name=e.data.name,this.description=e.data.description,this.image=`http://amontefusco-002-site1.ktempurl.com${e.data.image}`}catch(e){console.error("Error fetching category:",e),alert("Error al cargar la categoría. Inténtalo de nuevo.")}},onFileChange(e){this.newImage=e.target.files[0]},async updateCategory(){const e=new FormData;e.append("name",this.name),e.append("description",this.description),this.newImage&&e.append("image",this.newImage);try{await f.A.put(`http://amontefusco-002-site1.ktempurl.com/api/categories/${this.$route.params.id}`,e,{headers:{"Content-Type":"multipart/form-data"}}),this.$router.push("/categories")}catch(t){console.error("Error updating category:",t),alert("Error al actualizar la categoría. Inténtalo de nuevo.")}}},mounted(){this.fetchCategory()}};const le=(0,c.A)(ce,[["render",se]]);var de=le;const ue={class:"container mt-5"},pe={class:"card"},me={class:"card-body"},ge={class:"list-group"},be=["onClick"],he=["onClick"],ke={class:"text-center mt-3"};function fe(e,t,a,r,n,i){return(0,o.uX)(),(0,o.CE)("div",ue,[t[1]||(t[1]=(0,o.Lk)("h2",{class:"text-center"},"Lista de Productos",-1)),(0,o.Lk)("div",pe,[(0,o.Lk)("div",me,[(0,o.Lk)("ul",ge,[((0,o.uX)(!0),(0,o.CE)(o.FK,null,(0,o.pI)(n.products,(e=>((0,o.uX)(),(0,o.CE)("li",{class:"list-group-item d-flex justify-content-between align-items-center",key:e.id},[(0,o.eW)((0,A.v_)(e.name)+" - $"+(0,A.v_)(e.price)+" ",1),(0,o.Lk)("div",null,[(0,o.Lk)("button",{class:"btn btn-warning btn-sm me-2",onClick:t=>i.editProduct(e.id)},"Editar",8,be),(0,o.Lk)("button",{class:"btn btn-danger btn-sm",onClick:t=>i.deleteProduct(e.id)},"Eliminar",8,he)])])))),128))]),(0,o.Lk)("div",ke,[(0,o.Lk)("button",{class:"btn btn-primary",onClick:t[0]||(t[0]=(...e)=>i.createNewProduct&&i.createNewProduct(...e))},"Agregar Nuevo Producto")])])])])}const ye="http://amontefusco-002-site1.ktempurl.com/api";var Le={getAllProducts(){return f.A.get(`${ye}/products/all`)},getProduct(e){return f.A.get(`${ye}/products/${e}`)},createProduct(e){return f.A.post(`${ye}/products`,e)},updateProduct(e,t){return f.A.put(`${ye}/products/${e}`,t)},deleteProduct(e){return f.A.delete(`${ye}/products/${e}`)}},ve={data(){return{products:[]}},async created(){const e=await Le.getAllProducts();this.products=e.data},methods:{createNewProduct(){this.$router.push("/products/new")},editProduct(e){this.$router.push(`/products/${e}/edit`)},async deleteProduct(e){await Le.deleteProduct(e),this.products=this.products.filter((t=>t.id!==e))}}};const Ce=(0,c.A)(ve,[["render",fe]]);var we=Ce;const Ie={class:"container mt-5"},$e={class:"card"},Ae={class:"card-body"},Fe={class:"mb-3"},Pe={class:"mb-3"},xe={class:"mb-3"},Ee=["value"],De={class:"mb-3"},Xe={class:"mb-3"},Ue={class:"mb-3"},Ve={class:"text-center"};function qe(e,t,a,n,i,s){return(0,o.uX)(),(0,o.CE)("div",Ie,[t[16]||(t[16]=(0,o.Lk)("h2",{class:"text-center"},"Crear Nuevo Producto",-1)),(0,o.Lk)("div",$e,[(0,o.Lk)("div",Ae,[(0,o.Lk)("form",{onSubmit:t[7]||(t[7]=(0,r.D$)(((...e)=>s.createProduct&&s.createProduct(...e)),["prevent"]))},[(0,o.Lk)("div",Fe,[t[8]||(t[8]=(0,o.Lk)("label",{for:"name",class:"form-label"},"Nombre:",-1)),(0,o.bo)((0,o.Lk)("input",{"onUpdate:modelValue":t[0]||(t[0]=e=>i.name=e),type:"text",id:"name",class:"form-control",required:"",placeholder:"Ingresa el nombre del producto"},null,512),[[r.Jo,i.name]])]),(0,o.Lk)("div",Pe,[t[9]||(t[9]=(0,o.Lk)("label",{for:"description",class:"form-label"},"Descripción:",-1)),(0,o.bo)((0,o.Lk)("textarea",{"onUpdate:modelValue":t[1]||(t[1]=e=>i.description=e),id:"description",class:"form-control",required:"",placeholder:"Ingresa una descripción"},null,512),[[r.Jo,i.description]])]),(0,o.Lk)("div",xe,[t[11]||(t[11]=(0,o.Lk)("label",{for:"categoryId",class:"form-label"},"Categoría:",-1)),(0,o.bo)((0,o.Lk)("select",{"onUpdate:modelValue":t[2]||(t[2]=e=>i.categoryId=e),id:"categoryId",class:"form-select",required:""},[t[10]||(t[10]=(0,o.Lk)("option",{value:"",disabled:""},"Selecciona una categoría",-1)),((0,o.uX)(!0),(0,o.CE)(o.FK,null,(0,o.pI)(i.categories,(e=>((0,o.uX)(),(0,o.CE)("option",{key:e.id,value:e.id},(0,A.v_)(e.name),9,Ee)))),128))],512),[[r.u1,i.categoryId]])]),(0,o.Lk)("div",De,[t[12]||(t[12]=(0,o.Lk)("label",{for:"price",class:"form-label"},"Precio:",-1)),(0,o.bo)((0,o.Lk)("input",{"onUpdate:modelValue":t[3]||(t[3]=e=>i.price=e),type:"number",id:"price",class:"form-control",required:"",placeholder:"Ingresa el precio del producto"},null,512),[[r.Jo,i.price]])]),(0,o.Lk)("div",Xe,[t[13]||(t[13]=(0,o.Lk)("label",{for:"isFeatured",class:"form-label"},"Destacado:",-1)),(0,o.bo)((0,o.Lk)("input",{type:"checkbox","onUpdate:modelValue":t[4]||(t[4]=e=>i.isFeatured=e),id:"isFeatured"},null,512),[[r.lH,i.isFeatured]])]),(0,o.Lk)("div",Ue,[t[14]||(t[14]=(0,o.Lk)("label",{for:"image",class:"form-label"},"Imagen:",-1)),(0,o.Lk)("input",{onChange:t[5]||(t[5]=(...e)=>s.onFileChange&&s.onFileChange(...e)),type:"file",id:"image",class:"form-control",accept:"image/*"},null,32)]),(0,o.Lk)("div",Ve,[t[15]||(t[15]=(0,o.Lk)("button",{type:"submit",class:"btn btn-primary"},"Crear Producto",-1)),(0,o.Lk)("button",{type:"button",class:"btn btn-secondary ms-3",onClick:t[6]||(t[6]=t=>e.$router.push("/products"))},"Cancelar")])],32)])])])}var Ne={data(){return{name:"",description:"",categoryId:"",price:"",isFeatured:!1,image:null,categories:[]}},methods:{onFileChange(e){this.image=e.target.files[0]},async createProduct(){const e=new FormData;e.append("name",this.name),e.append("description",this.description),e.append("categoryId",this.categoryId),e.append("price",this.price),e.append("isFeatured",this.isFeatured),e.append("image",this.image);try{await f.A.post("http://amontefusco-002-site1.ktempurl.com/api/products/create",e,{headers:{"Content-Type":"multipart/form-data"}}),this.$router.push("/products")}catch(t){console.error("Error creando el producto:",t),alert("Hubo un error al crear el producto. Inténtalo de nuevo.")}this.name="",this.description="",this.categoryId="",this.price="",this.isFeatured=!1,this.image=null},async fetchCategories(){try{const e=await f.A.get("http://amontefusco-002-site1.ktempurl.com/api/categories/all");this.categories=e.data}catch(e){console.error("Error fetching categories:",e)}}},mounted(){this.fetchCategories()}};const Je=(0,c.A)(Ne,[["render",qe]]);var Oe=Je;const Se={class:"container mt-5"},_e={class:"card"},je={class:"card-body"},Te={class:"mb-3"},He={class:"mb-3"},ze={class:"mb-3"},We={class:"mb-3"},Ke={class:"mb-3"},Me={class:"mb-3"},Qe={class:"mt-2"},Be=["src"],Ge={class:"mb-3"},Re={class:"text-center"};function Ye(e,t,a,n,i,s){return(0,o.uX)(),(0,o.CE)("div",Se,[t[16]||(t[16]=(0,o.Lk)("h2",{class:"text-center"},"Editar Producto",-1)),(0,o.Lk)("div",_e,[(0,o.Lk)("div",je,[(0,o.Lk)("form",{onSubmit:t[7]||(t[7]=(0,r.D$)(((...e)=>s.updateProduct&&s.updateProduct(...e)),["prevent"]))},[(0,o.Lk)("div",Te,[t[8]||(t[8]=(0,o.Lk)("label",{for:"name",class:"form-label"},"Nombre:",-1)),(0,o.bo)((0,o.Lk)("input",{"onUpdate:modelValue":t[0]||(t[0]=e=>i.name=e),type:"text",id:"name",class:"form-control",required:"",placeholder:"Ingresa el nombre del producto"},null,512),[[r.Jo,i.name]])]),(0,o.Lk)("div",He,[t[9]||(t[9]=(0,o.Lk)("label",{for:"description",class:"form-label"},"Descripción:",-1)),(0,o.bo)((0,o.Lk)("textarea",{"onUpdate:modelValue":t[1]||(t[1]=e=>i.description=e),id:"description",class:"form-control",required:"",placeholder:"Ingresa una descripción"},null,512),[[r.Jo,i.description]])]),(0,o.Lk)("div",ze,[t[10]||(t[10]=(0,o.Lk)("label",{for:"categoryId",class:"form-label"},"Categoría ID:",-1)),(0,o.bo)((0,o.Lk)("input",{"onUpdate:modelValue":t[2]||(t[2]=e=>i.categoryId=e),type:"number",id:"categoryId",class:"form-control",required:"",placeholder:"Ingresa el ID de la categoría"},null,512),[[r.Jo,i.categoryId]])]),(0,o.Lk)("div",We,[t[11]||(t[11]=(0,o.Lk)("label",{for:"price",class:"form-label"},"Precio:",-1)),(0,o.bo)((0,o.Lk)("input",{"onUpdate:modelValue":t[3]||(t[3]=e=>i.price=e),type:"number",id:"price",class:"form-control",required:"",placeholder:"Ingresa el precio del producto"},null,512),[[r.Jo,i.price]])]),(0,o.Lk)("div",Ke,[t[12]||(t[12]=(0,o.Lk)("label",{for:"isFeatured",class:"form-label"},"Destacado:",-1)),(0,o.bo)((0,o.Lk)("input",{type:"checkbox","onUpdate:modelValue":t[4]||(t[4]=e=>i.isFeatured=e),id:"isFeatured"},null,512),[[r.lH,i.isFeatured]])]),(0,o.Lk)("div",Me,[t[13]||(t[13]=(0,o.Lk)("label",null,"Imagen Actual:",-1)),(0,o.Lk)("div",Qe,[i.image?((0,o.uX)(),(0,o.CE)("img",{key:0,src:i.image,alt:"Imagen Actual",class:"img-thumbnail",style:{width:"150px",height:"auto"}},null,8,Be)):(0,o.Q3)("",!0)])]),(0,o.Lk)("div",Ge,[t[14]||(t[14]=(0,o.Lk)("label",{for:"image",class:"form-label"},"Cambiar Imagen:",-1)),(0,o.Lk)("input",{onChange:t[5]||(t[5]=(...e)=>s.onFileChange&&s.onFileChange(...e)),type:"file",id:"image",class:"form-control",accept:"image/*"},null,32)]),(0,o.Lk)("div",Re,[t[15]||(t[15]=(0,o.Lk)("button",{type:"submit",class:"btn btn-primary"},"Actualizar Producto",-1)),(0,o.Lk)("button",{type:"button",class:"btn btn-secondary ms-3",onClick:t[6]||(t[6]=t=>e.$router.push("/products"))},"Cancelar")])],32)])])])}var Ze={data(){return{name:"",description:"",categoryId:"",price:"",isFeatured:!1,image:null,newImage:null}},methods:{async fetchProduct(){try{const e=await f.A.get(`http://amontefusco-002-site1.ktempurl.com/api/products/${this.$route.params.id}`),t=e.data;this.name=t.name,this.description=t.description,this.categoryId=t.categoryId,this.price=t.price,this.isFeatured=t.isFeatured,this.image=`http://amontefusco-002-site1.ktempurl.com${t.image}`}catch(e){console.error("Error al obtener el producto:",e),alert("Hubo un error al cargar el producto. Inténtalo de nuevo.")}},onFileChange(e){this.newImage=e.target.files[0]},async updateProduct(){const e=new FormData;e.append("name",this.name),e.append("description",this.description),e.append("categoryId",this.categoryId),e.append("price",this.price),e.append("isFeatured",this.isFeatured),this.newImage&&e.append("image",this.newImage);try{await f.A.put(`http://amontefusco-002-site1.ktempurl.com/api/products/${this.$route.params.id}`,e,{headers:{"Content-Type":"multipart/form-data"}}),this.$router.push("/products")}catch(t){console.error("Error actualizando el producto:",t),alert("Hubo un error al actualizar el producto. Inténtalo de nuevo.")}}},created(){this.fetchProduct()}};const et=(0,c.A)(Ze,[["render",Ye]]);var tt=et;const at=[{path:"/",redirect:"/admin/login"},{path:"/admin/login",component:v},{path:"/dashboard",component:$},{path:"/categories",component:S},{path:"/categories/new",component:G},{path:"/categories/:id/edit",component:de},{path:"/products",component:we},{path:"/products/new",component:Oe},{path:"/products/:id/edit",component:tt}],rt=(0,u.aE)({history:(0,u.LA)(),routes:at});var ot=rt;(0,r.Ef)(d).use(ot).mount("#app")}},t={};function a(r){var o=t[r];if(void 0!==o)return o.exports;var n=t[r]={exports:{}};return e[r].call(n.exports,n,n.exports,a),n.exports}a.m=e,function(){var e=[];a.O=function(t,r,o,n){if(!r){var i=1/0;for(d=0;d<e.length;d++){r=e[d][0],o=e[d][1],n=e[d][2];for(var s=!0,c=0;c<r.length;c++)(!1&n||i>=n)&&Object.keys(a.O).every((function(e){return a.O[e](r[c])}))?r.splice(c--,1):(s=!1,n<i&&(i=n));if(s){e.splice(d--,1);var l=o();void 0!==l&&(t=l)}}return t}n=n||0;for(var d=e.length;d>0&&e[d-1][2]>n;d--)e[d]=e[d-1];e[d]=[r,o,n]}}(),function(){a.n=function(e){var t=e&&e.__esModule?function(){return e["default"]}:function(){return e};return a.d(t,{a:t}),t}}(),function(){a.d=function(e,t){for(var r in t)a.o(t,r)&&!a.o(e,r)&&Object.defineProperty(e,r,{enumerable:!0,get:t[r]})}}(),function(){a.g=function(){if("object"===typeof globalThis)return globalThis;try{return this||new Function("return this")()}catch(e){if("object"===typeof window)return window}}()}(),function(){a.o=function(e,t){return Object.prototype.hasOwnProperty.call(e,t)}}(),function(){a.r=function(e){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})}}(),function(){var e={524:0};a.O.j=function(t){return 0===e[t]};var t=function(t,r){var o,n,i=r[0],s=r[1],c=r[2],l=0;if(i.some((function(t){return 0!==e[t]}))){for(o in s)a.o(s,o)&&(a.m[o]=s[o]);if(c)var d=c(a)}for(t&&t(r);l<i.length;l++)n=i[l],a.o(e,n)&&e[n]&&e[n][0](),e[n]=0;return a.O(d)},r=self["webpackChunkvue_axion"]=self["webpackChunkvue_axion"]||[];r.forEach(t.bind(null,0)),r.push=t.bind(null,r.push.bind(r))}();var r=a.O(void 0,[504],(function(){return a(6062)}));r=a.O(r)})();
//# sourceMappingURL=app.dbfc93fb.js.map