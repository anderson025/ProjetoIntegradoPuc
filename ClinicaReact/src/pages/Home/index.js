import { Box, styled, Typography } from '@mui/material';
import * as React from 'react';
import MenuAppBar from '../../components/MenuAppBar';


import './styles.css';


const DrawerHeader = styled('div')(({ theme }) => ({
  display: 'flex',
  alignItems: 'center',
  justifyContent: 'flex-end',
  padding: theme.spacing(0, 1),
  // necessary for content to be below app bar
  ...theme.mixins.toolbar,
}));



export default function Home(){

//   const theme = useTheme();
//   const [open, setOpen] = React.useState(false);
//   const navigate = useNavigate();

  const email = localStorage.getItem('email');
//   const {funcionarioId} = useParams();
//   var url_atual = window.location.href;

//   const handleDrawerOpen = () => {
//     setOpen(true);
//   };

//   const handleDrawerClose = () => {
//     setOpen(false);
//   };
  
//   async function logout(){
//     try {
//         localStorage.clear();
//         localStorage.setItem('token', '');
        
//         navigate('/');
//     } catch (error) {
//         alert('Não foi possível realizar logout' + error);
//     }
//   }

  return (
    
        
    <Box sx={{ display: 'flex' }}>
        
        <MenuAppBar/>
        <div className='center-datagrid'>
        <Box sx={{ height: 400, width: '100%' }}>
        <Typography paragraph>
        <header>
            <span>Bem vindo, <strong>{email}</strong>!</span>
                
        </header>
        </Typography>
        <Typography paragraph>
            
            
        </Typography>
        </Box>
        </div>
        </Box>
    



    // <Box sx={{ display: 'flex' }}>
    //   <CssBaseline />
    //   <AppBar position="fixed" open={open}>
    //     <Toolbar>
    //       <IconButton
    //         color="inherit"
    //         aria-label="open drawer"
    //         onClick={handleDrawerOpen}
    //         edge="start"
    //         sx={{
    //           marginRight: 5,
    //           ...(open && { display: 'none' }),
    //         }}
    //       >
    //         <MenuIcon />
    //       </IconButton>
    //       <Typography variant="h6" noWrap component="div">
    //         Sistema de Clínica
    //       </Typography>
    //     </Toolbar>
    //   </AppBar>
    //   <Drawer variant="permanent" open={open}>
    //     <DrawerHeader>
    //       <IconButton onClick={handleDrawerClose}>
    //         {theme.direction === 'rtl' ? <ChevronRightIcon /> : <ChevronLeftIcon />}
    //       </IconButton>
    //     </DrawerHeader>
    //     <Divider />
    //     <List>
    //       {['Agenda', 'Pacientes', 'Funcionarios', 'Avaliações'].map((text, index) => (
            
           
    //         <ListItem key={text} disablePadding sx={{ display: 'block' }}
    //             onClick={() => navigate('/'+text)}
    //         >
               
    //           <ListItemButton
    //             sx={{
    //               minHeight: 48,
    //               justifyContent: open ? 'initial' : 'center',
    //               px: 2.5,
    //             }}
    //             // component={Link} to='/funcionarios'
                   
                
               
                
    //           >
                
                
    //             <ListItemIcon
    //               sx={{
    //                 minWidth: 0,
    //                 mr: open ? 3 : 'auto',
    //                 justifyContent: 'center',
    //               }}
    //             >
    //                 {text === 'Agenda' ? <AlarmIcon /> : null}  
    //                 {text === 'Pacientes' ? <AccessibilityIcon /> : null}  
    //                 {text === 'Funcionarios' ? <AssignmentIndIcon /> : null} 
    //                 {text === 'Avaliações' ? <LoopIcon /> : null}
    //               {/* {index % 2 === 0 ? <AlarmIcon /> : <MailIcon />} */}
    //             </ListItemIcon>
    //             <ListItemText primary={text} sx={{ opacity: open ? 1 : 0 }} />                
    //           </ListItemButton>              
    //         </ListItem>
           
    //       ))}
    //     </List>
    //     <Divider />
    //     <List>
    //       {['Perfil', 'Sair'].map((text, index) => (
    //         <ListItem key={text} disablePadding sx={{ display: 'block' }}
    //             onClick={text === 'Sair'? logout: null}
    //         >
    //           <ListItemButton
    //             sx={{
    //               minHeight: 48,
    //               justifyContent: open ? 'initial' : 'center',
    //               px: 2.5,
    //             }}
    //           >
    //             <ListItemIcon
    //               sx={{
    //                 minWidth: 0,
    //                 mr: open ? 3 : 'auto',
    //                 justifyContent: 'center',
    //               }}
    //             >
                    
    //                {text === 'Perfil' ? <AccountCircleIcon /> : null} 
    //                {text === 'Sair' ? <LogoutIcon /> : null} 
    //               {/* {index % 2 === 0 ? <InboxIcon /> : <MailIcon />} */}
    //             </ListItemIcon>
    //             <ListItemText primary={text} sx={{ opacity: open ? 1 : 0 }} />
    //           </ListItemButton>
    //         </ListItem>
    //       ))}
    //     </List>
    //   </Drawer>
    //   <Box component="main" sx={{ flexGrow: 1, p: 3 }}>
    //     <DrawerHeader />
    //     <Typography paragraph>
    //     <header>
    //             <span>Bem vindo, <strong>{email}</strong>!</span>              
                
    //     </header>
    //     </Typography>
    //     <Typography paragraph>

    //         <section className='body-aplication'>                
    //             <MainRoutes />
                
                
    //         </section>
            
    //     </Typography>
    //   </Box>
    // </Box>
  )
}
