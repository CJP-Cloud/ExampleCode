<?php

//DELETE LATER
//http://localhost/AshWeb/website.php
//http://localhost/phpmyadmin/index.php?route=/sql&db=coistest&table=animals&pos=0



error_reporting(E_ERROR | E_PARSE);

session_start();

$ch = curl_init();
curl_setopt($ch, CURLOPT_URL, $_SESSION['url']);
curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);


$output = curl_exec($ch);
curl_close($ch);

$data = json_decode($output, true);

$size25 = $_POST['size25'];
$size50 = $_POST['size50'];
$size100 = $_POST['size100'];
$nextPage = $_POST['nextPage'];

$pageNumber = $_POST['pageNumber'];

//checks if pageSize is set or not
//if not it will set it to the default 50
//50 is the default page size

//Automatically updates from Inatrualist to get the most recent 50 obeservations
if($_SESSION['url'] == ""){
$_SESSION['url'] = "https://api.inaturalist.org/v1/observations?photos=true&sounds=false&project_id=128582&q=&search_on=names&page=1&per_page=50&order=desc&order_by=created_at";
}

//avoids error pagesize cause itll try to divide by zero otherwise
if($_SESSION['pageSize'] == ""){
$_SESSION['pageSize'] = 50;
}

$total_results = $data['total_results'];
$results_per_page =  $_SESSION['pageSize'];
$num_pages = ceil($total_results / $results_per_page);



function resetPage() {
  $pagination_index = strpos($_SESSION['url'], 'page=') + strlen('page=');
  $pagination_end = strpos($_SESSION['url'], '&per');

  $_SESSION['url'] = substr($_SESSION['url'], 0, $pagination_index).substr($_SESSION['url'], $pagination_end);

  $_SESSION['pagination'] = 1;

  $_SESSION['url'] = substr($_SESSION['url'], 0, $pagination_index).$_SESSION['pagination'].substr($_SESSION['url'], $pagination_index);
}

if (isset($_POST['size25'])) {
  resetPage();
  // Find the index position of 'per_page='
  // We add strlen('per_page=') in order to concatenate the page size variable at the end of 'per_page='
  $page_index = strpos($_SESSION['url'], 'per_page=') + strlen('per_page=');
  // Find the index position of the string '&order' in the URL
  $page_end = strpos($_SESSION['url'], '&order');

  //changes page size variable
  $_SESSION['pageSize'] = 25;

  // Changes the URL to show 25 results per page
  $_SESSION['url'] = substr($_SESSION['url'], 0, $page_index).$_SESSION['pageSize'].substr($_SESSION['url'],$page_end);
}


if(isset($_POST['size50'])){
  resetPage();
  // Find the index position of 'per_page='
  // We add strlen('per_page=') in order to concatenate the page size variable at the end of 'per_page='
  $page_index = strpos($_SESSION['url'], 'per_page=') + strlen('per_page=');
  // Find the index position of the string '&order' in the URL
  $page_end = strpos($_SESSION['url'], '&order');

  //changes page size variable
  $_SESSION['pageSize'] = 50;

  // Changes the URL to show 25 results per page
  $_SESSION['url'] = substr($_SESSION['url'], 0, $page_index).$_SESSION['pageSize'].substr($_SESSION['url'],$page_end);
}

if(isset($_POST['size100'])){
  resetPage();
  // Find the index position of 'per_page='
  // We add strlen('per_page=') in order to concatenate the page size variable at the end of 'per_page='
  $page_index = strpos($_SESSION['url'], 'per_page=') + strlen('per_page=');
  // Find the index position of the string '&order' in the URL
  $page_end = strpos($_SESSION['url'], '&order');

  //changes page size variable
  $_SESSION['pageSize'] = 100;

  // Changes the URL to show 25 results per page
  $_SESSION['url'] = substr($_SESSION['url'], 0, $page_index).$_SESSION['pageSize'].substr($_SESSION['url'],$page_end);
}

// Search Bar
if(isset($_POST['button'])) {
  // Grab what user typed in search bar
  $searched = $_POST['search'];
  resetPage();

  // Find the index position of the string 'q=' in the URL
  // We add strlen('q=') in order to concatenate the $searched substring at the end of 'q='
  $start_index = strpos($_SESSION['url'], 'q=') + strlen('q=');
  // Find the index position of the string 'search_on' in the URL
  $end_index = strpos($_SESSION['url'], '&search_on');

  // Reset the URL to back to default (removes any previous searches from the URL that was saved from the session)
  $_SESSION['url'] = substr($_SESSION['url'], 0, $start_index).substr($_SESSION['url'], $end_index);

  // Take what the user searched and add it to the URL (In between 'q=' and &search_on)
  $_SESSION['url'] = substr($_SESSION['url'], 0, $start_index).$searched.substr($_SESSION['url'],$start_index);

  // Send API request with new URL
  $response = file_get_contents($_SESSION['url']);
  // Json file
  $dataTest = json_decode($response);
}

if(isset($_POST['nextPage'])){

  // next page
  $pagination_index = strpos($_SESSION['url'], 'page=') + strlen('page=');
  $pagination_end = strpos($_SESSION['url'], '&per');

  $_SESSION['url'] = substr($_SESSION['url'], 0, $pagination_index).substr($_SESSION['url'], $pagination_end);

  if ($_SESSION['pagination'] < $num_pages) {
    $_SESSION['pagination'] += 1;
  }
  $_SESSION['url'] = substr($_SESSION['url'], 0, $pagination_index).$_SESSION['pagination'].substr($_SESSION['url'], $pagination_index);
}

if(isset($_POST['previousPage'])){

  // previous page
  $pagination_index = strpos($_SESSION['url'], 'page=') + strlen('page=');
  $pagination_end = strpos($_SESSION['url'], '&per');

  $_SESSION['url'] = substr($_SESSION['url'], 0, $pagination_index).substr($_SESSION['url'], $pagination_end);

  if ($_SESSION['pagination'] > 1 ) {
    $_SESSION['pagination'] -= 1;
  }

  $_SESSION['url'] = substr($_SESSION['url'], 0, $pagination_index).$_SESSION['pagination'].substr($_SESSION['url'], $pagination_index);
}

$response = file_get_contents($_SESSION['url']);
$dataTest = json_decode($response);

//REFERENCES ----------------------------------------------------
  $name = $data['results'][0]['taxon']['preferred_common_name'];
  
  $latin = $data['results'][0]['taxon']['name'];

  $date = $data['results'][0]['observed_on_details']['date'];
  
  $picture = $data['results'][0]['taxon']['default_photo']['url'];

  $risk = $data['results'][0]['taxon']['threatened'];

  $invasive = $data['results'][0]['taxon']['native'];
//---------------------------------------------------------------


?>

<!DOCTYPE html>
<html lang="en-US" class="no-js">
<head>
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel='stylesheet' href='css/style.min.css?ver=1.7.10' media='all'/>
    <link rel="stylesheet" href="css/main.css">

</head>

<body class="home page-template-default page page-id-28 wp-embed-responsive inspiro-front-page has-header-image page-layout-full-width ">

<aside id="side-nav" class="side-nav" tabindex="-1">
    <div class="side-nav__scrollable-container">
        <div class="side-nav__wrap">
            <div class="side-nav__close-button">
                <button type="button" class="navbar-toggle">
                    <span class="screen-reader-text">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
            </div>
            <nav class="mobile-menu-wrapper" aria-label="Mobile Menu" role="navigation">
                <ul id="menu-bluehost-website-builder" class="nav navbar-nav">
                    <li id="menu-item-1678"
                        class="menu-item current-menu-item ">
                        <a href="#" aria-current="page">Home</a></li>
                    <li id="menu-item-1579"
                        class="menu-item"><a href="#">About
                        Us</a></li>
                    <li id="menu-item-1784"
                        class="menu-item"><a href="#">Get
                        Involved</a></li>
                    <li id="menu-item-1742"
                        class="menu-item"><a href="#">Cleanups</a>
                    </li>
                    <li id="menu-item-19" class="">
                        <a href="#">History</a></li>
                    <li id="menu-item-1616"
                        class="menu-item"><a href="#">In
                        The News</a></li>
                    <li id="menu-item-1578"
                        class="menu-item"><a href="#">Contact</a>
                    </li>
                </ul>
            </nav>
        </div>
    </div>
</aside>
<div class="side-nav-overlay"></div>

<div id="page" class="site">
    <a class="skip-link screen-reader-text" href="#content">Skip to content</a>

    <header id="masthead" class="site-header" role="banner">
        <div id="site-navigation" class="navbar">
            <div class="header-inner inner-wrap  ">

                <div class="header-logo-wrapper">
                    <a href="#" title="" class="custom-logo-text"></a></div>

                <div class="header-navigation-wrapper">
                    <nav class="primary-menu-wrapper navbar-collapse collapse" aria-label="Top Horizontal Menu"
                         role="navigation">
                        <ul id="menu-bluehost-website-builder-1" class="nav navbar-nav dropdown sf-menu">
                            <li class="menu-item current-menu-item">
                                <a href="#" aria-current="page">Home</a></li>
                            <li class="menu-item"><a
                                    href="#">About Us</a></li>
                            <li class="menu-item"><a
                                    href="#">Get Involved</a></li>
                            <li class="menu-item"><a
                                    href="#">Cleanups</a></li>
                            <li class="menu-item"><a
                                    href="#">History</a></li>
                            <li class="menu-item"><a
                                    href="#">In The News</a></li>
                            <li class="menu-item"><a
                                    href="#">Contact</a></li>
                        </ul>
                    </nav>
                </div>

                <div class="header-widgets-wrapper">


                    <button type="button" class="navbar-toggle">
                        <span class="screen-reader-text">Toggle sidebar &amp; navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                </div>
            </div><!-- .inner-wrap -->
        </div><!-- #site-navigation -->
    </header><!-- #masthead -->


    <div class="custom-header">
        <div class="site-branding">
            <div class="inner-wrap">

                <div class="site-branding-text">
                    <h1 class="site-title"><a href="" target="_blank">Welcome to the Ashburnham Memorial Stewardship Group</a></h1>

                </div><!-- .site-branding-text -->

                <div class="custom-header-button-wrapper">
                    <a class="custom-header-button button" href="" target="_blank" rel="nofollow"
                       style="display: none;">
                    </a>
                </div><!-- .custom-header-button -->

            </div><!-- .inner-wrap -->
        </div><!-- .site-branding -->


        <div class="custom-header-media">
            <div id="wp-custom-header" class="wp-custom-header">
				<img src="images/rock.jpg" width="2000" height="1201" alt="">

			</div>

        </div>

        <div id="scroll-to-content" title="Scroll down to content">
            <span class="screen-reader-text">Scroll down to content</span>
        </div>
    </div><!-- .custom-header -->

    <div class="site-content-contain" >
        <div id="content" class="site-content">


            <main id="main" class="site-main" role="main">


                <article id="post-28" class="post-28 page type-page status-publish hentry">


                    <header class="entry-header">

                        <div class="inner-wrap"></div><!-- .inner-wrap -->
                    </header><!-- .entry-header -->

                    <div class="entry-content">
                        <div>
                            <section>
                                <div class="">
                                    <div class="">
                                        <div class="">
                                            <div>
                                            </div>
                                            <div class="">
                                                <div class="">
                                                </div>
                                            </div>
											<form method="post">
												<div>
													<p><a href="https://www.inaturalist.org/projects/ashburnham-memorial-park-peterborough-armour-hill">Ashburnham iNaturalist Project </a></p>
													<p><a href="https://ashburnhamstewardship.com/">Ashburnham Stewardship Website </a> </p>
												</div>
												<div><input class="search" id="search" name="search" type="text"
															placeholder="Search" />
													<input id="button" name="button" type="submit">

                                                    
													<input class="size" id="size25" name="size25" type="submit" value= "25">
													<input class="size" id="size50" name="size50" type="submit" value= "50" >
													<input class="size" id="size100" name="size100" type="submit" value= "100">
                                                 
												</div>
												<table>
													<thead>
													<tr>
														<th>Name</th>
														<th>Latin name</th>
														<th>Date Observed</th>
														<th>At Risk</th>
														<th>Invasive</th>
														<th>Picture</th>
													</tr>
													</thead>
													<tbody>
													<?php
      
                            foreach($dataTest->results as $row): ?>
                          <tr>
                            <?php 
                            try{
                            $Name = $row->taxon->preferred_common_name;
                            $latin = $row->taxon->name;
                            $date = $row->observed_on_details->date;
                            $picture = $row->taxon->default_photo->url;
                            $risk = $row->taxon->threatened;
                            if($risk === TRUE){
                              $riskText = 'True';
                            }
                            else{
                              $riskText = 'N/A';
                            }
                            
                            $inv = $row->taxon->native;
                            if($inv === TRUE){
                              $invText = 'N/A';
                            }
                            else{
                              $invText = 'True';
                            }
                          }
                          catch (Exception $exec){ 

                          }
                            ?>
                            

                            <td><?php echo $Name;?></td>
                            <td><?php echo $latin?></td>
                            <td><?php echo $date?></td>
                            <td><?php echo $riskText?></td>
                            <td><?php echo $invText?></td>
                            <td><?php echo "<img width=100%; src='".$picture."'>"?></td> 
                          </tr>
                          <?php endforeach ?>
                          </tbody>
                        </table>

                                                
                                                 <diV><input class="size" id="previousPage" name="previousPage" type="submit" value= "Previous Page">
                                                    <input class="size" id="nextPage" name="nextPage" type="submit" value= "Next Page"></diV>
                                                
												
                        

                                            <div class="">
                                                <div class="">
                                                    <p>Anyone interested in more information or working with AMSG can
                                                        email the group at: <a class="" href="mailto:test@gmail.com"
                                                                               target="" rel="noopener"
                                                                               data-href="mailto:test@gmail.com"
                                                                               data-target="">test@gmail.com</a></p>
                                                </div>
                                            </div>
											<div style="text-align: center">
											<img src="images/forest.jpg" width="400" height="200" alt="">
											</div>
                                        </div>
                                    </div>
                                </div>
                            </section>

                        </div>
                    </div><!-- .entry-content -->
                </article><!-- #post-28 -->

            </main><!-- #main -->


        </div><!-- #content -->


        <footer id="colophon" class="site-footer" role="contentinfo">
            <div class="inner-wrap">


                <aside class="footer-widgets widgets widget-columns-3" role="complementary" aria-label="Footer">

                    <div class="widget-column footer-widget-1">
                        <section id="block-7" class="widget widget_block widget_text">
                            <p></p>
                        </section>
                    </div>

                </aside><!-- .widget-area -->

                <div class="site-footer-separator"></div>

                <div class="site-info">
		<span class="copyright">
		<span>
			<a href="https://wordpress.org/" target="_blank">
				Powered by WordPress			</a>
		</span>
		<span>
			 WordPress Theme by <a href="https://www.wp.com/" target="_blank" rel="nofollow">WP</a>
		</span>
	</span>
                </div><!-- .site-info -->
            </div><!-- .inner-wrap -->
        </footer><!-- #colophon -->
    </div><!-- .site-content-contain -->
</div><!-- #page -->

<script src="https://code.jquery.com/jquery-3.1.0.js"></script>
<script src='js/plugins.min.js?ver=1.7.10' id='inspiro-lite-js-plugins-js'></script>
<script src='js/scripts.min.js?ver=1.7.10' id='inspiro-lite-script-js'></script>

</body>

</html>