
 //for change input fields in pages for create todos and categories 
export  const onChange = ({target:{name,value}}:React.ChangeEvent<any>, setObject: React.Dispatch<React.SetStateAction<any>>) => {
    setObject((prev: any)=>{ 
      (prev as any)[name]=value;
       const newValue=  {...prev}
       return newValue;
       })}