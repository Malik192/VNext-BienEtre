export interface User {
 
    
    Pseudo: string;
    IdEmp: number;
 
    IdEmployee: number;
  };

export interface ProfileState {
    user?: User;
     Token:string;


    error: boolean;
};
export interface RootState {
     
  version: string;
};